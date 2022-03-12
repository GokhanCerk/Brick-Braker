using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform paddle;
    public bool inPlay;
    public float speed;
    public Transform explosion;
    public GameManager gm;
    public Transform powerUp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }
        
        if (!inPlay)
        {
            transform.position = paddle.position;
        }

        if (Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bottom"))
        {    
            rb.velocity = Vector2.zero;
            inPlay = false;
            gm.UpdateLives(-1);
        } 
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("brick"))
        {
           int randomChance = Random.Range(1, 101);
            if (randomChance < 50)
            {
                Instantiate(powerUp, collision.transform.position, collision.transform.rotation);
            }

           Transform newExplosion = Instantiate(explosion, collision.transform.position, collision.transform.rotation);
           Destroy(newExplosion.gameObject, 2.5f);
           gm.UpdateScore(collision.gameObject.GetComponent<BrickScript>().point);
           gm.UpdateNumberOfBricks();
           Destroy(collision.gameObject);
        }
    }
}
