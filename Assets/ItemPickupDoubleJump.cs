using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupDoubleJump : BaseItem
{
    [HideInInspector] public GameObject player;
    [HideInInspector] public GameObject boss;
    [HideInInspector] public SpriteRenderer sr;

    public GameObject unlockText;
    public Sprite chestOpened;

    public Animator chestVFX;

    void Start()
    {
        player = GameObject.Find("Player");
        boss = GameObject.Find("MiniBoss");

        sr = GetComponent<SpriteRenderer>();
    }

    public override void Initialise()
    {   
        if (boss.GetComponent<Boss_FSM>().bossDead)
        {
            player.GetComponent<Player_FSM>().doubleJumpUnlocked = true; //allow player to double jump

            sr.sprite = chestOpened;
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.08f);

            chestVFX.SetTrigger("chestOpened");

            unlockText.SetActive(true);
        }        
    }
}
