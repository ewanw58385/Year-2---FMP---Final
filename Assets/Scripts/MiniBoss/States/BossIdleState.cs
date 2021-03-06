using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : BaseState
{
    private Boss_FSM _bfsm;

    public BossIdleState(Boss_FSM stateMachine) : base("idle", stateMachine)
    {
        _bfsm = stateMachine;
    }
    
     public override void Enter()
    {
        base.Enter();

        _bfsm.bossAnim.Play("idle"); //plays idle animation
        _bfsm.bossRb.velocity = Vector2.zero; //stop AI from moving once player is out of range

        _bfsm.bm.shouldFlip = true;
        _bfsm.hitCondition = false;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (_bfsm.hitCondition == true)
        {
            _bfsm.ChangeState(_bfsm.hit);
        }

        if(_bfsm.bossDead)
        {
            _bfsm.ChangeState(_bfsm.dead);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        if (_bfsm.bossAI.playerWithinRange == true) //if enemyAI script detects target (player) within range
        {
           _bfsm.ChangeState(_bfsm.moving); //transition to moving state;
        }
    }
}
