using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossBasicAttack : BaseState
{
    private FinalBoss_FSM _fbsm;
    private FinalBossCombatManager _fbcm;
    
    private bool preventAttackingEveryFrame;

    public FinalBossBasicAttack(FinalBoss_FSM stateMachine) : base("basicattack", stateMachine)
    {
        _fbsm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        _fbcm = _fbsm.fbcm; //instance of EnemyCombatManager

        preventAttackingEveryFrame = true;
        _fbsm.fbm.shouldFlip = true; 
        _fbsm.hitCondition = false;

        _fbsm.finalBossAnim.Play("basicattack");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

            if (_fbsm.finalBossAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.2f) //if anim is at point of hitting player 
            {
                if (preventAttackingEveryFrame) //apply damage in if statement to prevent the damage from being applied every frame
                {
                    Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(_fbcm.weakAttackPosition.position, _fbcm.weakAttackRange, _fbcm.playerLayerMask); //creates array of colliders which are within the boundary and are of the correct layermask 

                    foreach (Collider2D playerHit in playerToDamage) //for each enemy hit in the array declared above
                    {
                        _fbsm.player.GetComponent<Player_FSM>().hasBeenHit = true; //set the condition for transitioning to hit state to true
                        _fbsm.player.GetComponent<PlayerCombatManager>().TakeDamage(_fbcm.basicAttackDamage); //apply damage to player passing weak attack damage as parameter
                        //Debug.Log(playerToDamage.Length);
                    }

                    preventAttackingEveryFrame = false; //prevent iterating again
                }
            }            

        if (_fbsm.finalBossAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 2f) //if anim finished
        {
            _fbsm.fbm.shouldFlip = true; //allow enemy to flip before entering heavy attack
            _fbsm.ChangeState(_fbsm.heavyattack); //transition to moving state
        }

        if (_fbsm.hitCondition == true)
        {
            _fbsm.ChangeState(_fbsm.hit);
        }

        if(_fbsm.finalBossDead)
        {
            _fbsm.ChangeState(_fbsm.dead);
        }

        if (_fbsm.player != null) //if there is a player
        {
            float dist = Vector2.Distance(_fbsm.finalBossRb.position, _fbsm.player.transform.position); //calculate distance 

            if (dist >= _fbsm.finalBossAI.withinContinuedAttackRange) //if player walks away while mid attack
            {
                _fbsm.ChangeState(_fbsm.moving); //transition to moving state
            }
        }
        else //if there is not a player
        {
            return; //return out of function
        }
    }

    public override void Exit()
    {
        base.Exit();
        preventAttackingEveryFrame = false;
    }
}
