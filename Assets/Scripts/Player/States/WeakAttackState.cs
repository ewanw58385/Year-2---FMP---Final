using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakAttackState : BaseState
{
    public Player_FSM _psm;
    private PlayerCombatManager _pcm;
    
    private bool preventAttackingEveryFrame = true;
    private bool preventSecondAttackEveryFrame = true;

    public WeakAttackState(Player_FSM stateMachine) : base("weakattack", stateMachine)
    {
        _psm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        _pcm = _psm.GetComponent<PlayerCombatManager>();

        _psm.anim.Play("weak attack");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

            if (_psm.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.3f) //if attack animation is at the point of hitting the enemy (first slash)
            {
                if (preventAttackingEveryFrame)
                {
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(_pcm.weakAttackPos.position, _pcm.weakAttackRange, _pcm.enemyLayer); //creates array of colliders which are within the boundary and are of the correct layermask 

                    foreach (Collider2D enemyHit in enemiesToDamage) //for each enemy hit in the array declared above
                    {
                        enemyHit.GetComponent<Enemy_FSM>().hitCondition = true; //set the condition for transitioning to hit state to true
                        enemyHit.GetComponent<Enemy_FSM>().damageTaken = _pcm.weakAttackDamage; //damage float for hit state
                    }

                    Collider2D[] bossesToDamage = Physics2D.OverlapCircleAll(_pcm.weakAttackPos.position, _pcm.weakAttackRange, _pcm.bossLayer); //creates array of colliders which are within the boundary and are of the correct layermask 

                    foreach (Collider2D bossHit in bossesToDamage) //for each enemy hit in the array declared above
                    {
                        bossHit.GetComponent<Boss_FSM>().hitCondition = true; //set the condition for transitioning to hit state to true
                        bossHit.GetComponent<Boss_FSM>().damageTaken = _pcm.weakAttackDamage; //damage float for hit state
                    }

                    Collider2D[] finalBossesToDamage = Physics2D.OverlapCircleAll(_pcm.weakAttackPos.position, _pcm.weakAttackRange, _pcm.finalBossLayer); //creates array of colliders which are within the boundary and are of the correct layermask 

                    foreach (Collider2D finalBossHit in finalBossesToDamage) //for each enemy hit in the array declared above
                    {
                        finalBossHit.GetComponent<FinalBoss_FSM>().hitCondition = true; //set the condition for transitioning to hit state to true
                        finalBossHit.GetComponent<FinalBoss_FSM>().damageTaken = _pcm.weakAttackDamage; //damage float for hit state
                    }

                    Collider2D[] hiddenWalls = Physics2D.OverlapCircleAll(_pcm.weakAttackPos.position, _pcm.weakAttackRange, _pcm.hiddenWall);

                    foreach (Collider2D wall in hiddenWalls)
                    {
                        wall.GetComponent<RevealDungeon>().playerHitWall = true;
                    }

                    preventAttackingEveryFrame = false;
                }
            }

            if (_psm.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f)
            {
                if (Input.anyKey)
                {
                    _psm.ChangeState(_psm.idle);
                    preventAttackingEveryFrame = true;
                    preventSecondAttackEveryFrame = true;
                }
            }

            if (_psm.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f) //if attack animation is at the point of hitting the enemy (second slash)
            {
                if (preventSecondAttackEveryFrame)
                {
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(_pcm.weakAttackPos.position, _pcm.weakAttackRange, _pcm.enemyLayer); //creates array of colliders which are within the boundary and are of the correct layermask 

                        foreach (Collider2D enemyHit in enemiesToDamage) //for each enemy hit in the array declared above
                        {
                            enemyHit.GetComponent<Enemy_FSM>().hitCondition = true; //set the condition for transitioning to hit state to true
                            enemyHit.GetComponent<Enemy_FSM>().damageTaken = _pcm.weakAttackDamage; //damage float for hit state
                        }  

                    Collider2D[] bossesToDamage = Physics2D.OverlapCircleAll(_pcm.weakAttackPos.position, _pcm.weakAttackRange, _pcm.bossLayer); //creates array of colliders which are within the boundary and are of the correct layermask 

                        foreach (Collider2D bossHit in bossesToDamage) //for each enemy hit in the array declared above
                        {
                            bossHit.GetComponent<Boss_FSM>().hitCondition = true; //set the condition for transitioning to hit state to true
                            bossHit.GetComponent<Boss_FSM>().damageTaken = _pcm.weakAttackDamage; //damage float for hit state
                        }

                        
                    Collider2D[] finalBossesToDamage = Physics2D.OverlapCircleAll(_pcm.weakAttackPos.position, _pcm.weakAttackRange, _pcm.finalBossLayer); //creates array of colliders which are within the boundary and are of the correct layermask 

                    foreach (Collider2D finalBossHit in finalBossesToDamage) //for each enemy hit in the array declared above
                    {
                        finalBossHit.GetComponent<FinalBoss_FSM>().hitCondition = true; //set the condition for transitioning to hit state to true
                        finalBossHit.GetComponent<FinalBoss_FSM>().damageTaken = _pcm.weakAttackDamage; //damage float for hit state
                    }

                    preventSecondAttackEveryFrame = false;
                }
            }

        if (_psm.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f) //if attack has finished
        {
            _psm.ChangeState(_psm.idle); //change to idle state
            preventAttackingEveryFrame = true;
            preventSecondAttackEveryFrame = true;
        }

        if (_psm.hasBeenHit)
        {
            //_psm.ChangeState(_psm.hit);
        }
    }
}
