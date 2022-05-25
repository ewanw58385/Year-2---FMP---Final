using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossChestScript : BaseItem
{
    public Animator chestVFX;

    public Sprite chestOpened;
    [HideInInspector] public SpriteRenderer sr;

    public GameObject enemy; //assigned in inspector for each chest instance
    public GameObject keyText;    
    public SpecialPlatform sp; //assigned in inspector

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public override void Initialise()
    {   
        if (enemy.GetComponent<FinalBoss_FSM>().finalBossDead)
        {
            sr.sprite = chestOpened;
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.08f);
            chestVFX.SetTrigger("chestOpened");

            sp.keyPickedUp = true;

            keyText.SetActive(true);
        }        
    }
}
