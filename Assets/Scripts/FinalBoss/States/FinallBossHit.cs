using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinallBossHit : BaseState
{

    private FinalBoss_FSM _fbsm;
    private FinalBossCombatManager _fbcm;

    public FinallBossHit(FinalBoss_FSM stateMachine) : base ("hit", stateMachine)
    {
        _fbsm = stateMachine;
    }

        public override void Enter()
    {
        base.Enter();

        _fbsm.hitCondition = false; //reset the condition to transition to this state
        _fbsm.fbm.shouldFlip = true; //should be able to flip if hit

        _fbcm = _fbsm.transform.GetComponent<FinalBossCombatManager>(); //gets reference to combat manager for deducting health 

        _fbsm.finalBossAnim.Play("hit"); //plays hit anim
        _fbcm.ApplyDamage(_fbsm.damageTaken); //calls the apply damage function from the EnemyCombatManager, passing the damageTaken parameter (set in the player attack state) as the damage to be deducted.
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (_fbsm.hitCondition == true) //if gets hit again (while hit from first attack)
        {
            _fbsm.ChangeState(_fbsm.hit); //transition to hit (restart state)
        }

        if(_fbsm.finalBossDead)
        {
            _fbsm.ChangeState(_fbsm.dead);
        }

        if (_fbsm.finalBossAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.5f) //delay before transitioning to attacking
        {
            _fbsm.ChangeState(_fbsm.weakattack);
        }
    }

    public override void Exit()
    {
        base.Exit();

        _fbsm.damageTaken = 0f; //reset the damage float 
    }
}
