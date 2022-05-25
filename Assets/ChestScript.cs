using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : BaseItem
{
    public Animator chestVFX;

    public Sprite chestOpened;
    [HideInInspector] public SpriteRenderer sr;

    public GameObject enemy; //assigned in inspector for each chest instance
    

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public override void Initialise()
    {   
        if (enemy == null)
        {
            sr.sprite = chestOpened;
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.08f);

            chestVFX.SetTrigger("chestOpened");

            Debug.Log("opened a chest");
        }        
    }
}
