using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public int point;
    public int hitsToBreak;
    public Sprite hitSprite;

    /// <summary>
    /// 
    /// </summary>
    public void BreakBrick()
    {
        hitsToBreak--;
        GetComponent<SpriteRenderer>().sprite = hitSprite;
    }

}
