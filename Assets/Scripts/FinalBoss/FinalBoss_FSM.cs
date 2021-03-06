using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss_FSM : G_FSM
{
    [HideInInspector] public FinalBossIdle idle;
    [HideInInspector] public FinalBossMoving moving;
    [HideInInspector] public FinalBossWeakAttack weakattack;
    [HideInInspector] public FinalBossBasicAttack basicattack;
    [HideInInspector] public FinalBossHeavyAttack heavyattack;
    [HideInInspector] public FinallBossHit hit;
    [HideInInspector] public FinalBossDead dead;

    public FinalBossAI finalBossAI;
    public Rigidbody2D finalBossRb;
    public Animator finalBossAnim;
    public FinalBossCombatManager fbcm;
    public FinalBossManager fbm;
    public GameObject player;

    [HideInInspector] public bool hitCondition; //condition for transitioning to hit state, set to true on Player attack state 
    [HideInInspector] public float damageTaken; //float for holding the amount of damage taken. declared on player attack state, passed as a parameter within Hit state
    [HideInInspector] public bool finalBossDead; //bool for transitioning to dead state. Determined in the boss combat manager. 

    void Awake()
    {
        idle = new FinalBossIdle(this);
        moving = new FinalBossMoving(this);
        weakattack = new FinalBossWeakAttack(this);
        basicattack = new FinalBossBasicAttack(this);
        heavyattack = new FinalBossHeavyAttack(this);
        hit = new FinallBossHit(this);
        dead = new FinalBossDead(this);

        finalBossAI = GetComponent<FinalBossAI>();
        finalBossRb = GetComponent<Rigidbody2D>();
        finalBossAnim = GetComponentInChildren<Animator>();
        fbcm = GetComponent<FinalBossCombatManager>();
        fbm = GetComponent<FinalBossManager>();
        player = GameObject.Find("Player");
    }

    protected override BaseState GetInitialState() 
    {
        return idle;
    }
}
