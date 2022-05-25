using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealDungeon : MonoBehaviour
{
    public Animator wallAnim1;
    public Animator wallAnim2;
    public Animator wallAnim3;

    public Animator tilemapForeAnim;
    public Animator tilemapMidAnim;
    public Animator tilemapBackAnim;

    public Collider2D col;

    [HideInInspector] public bool playerHitWall;
    
    void Update()
    {
        if (playerHitWall)
        {
            wallAnim1.Play("wallReveal");
            wallAnim2.Play("wallReveal");
            wallAnim3.Play("wallReveal");

            tilemapForeAnim.Play("FadeInDungeon");
            tilemapMidAnim.Play("FadeInDungeon");
            tilemapBackAnim.Play("FadeInDungeon");

            col.enabled = false;
        }

    }
}
