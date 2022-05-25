using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossDead : BaseState
{
    public FinalBoss_FSM _fbsm;

    public FinalBossDead(FinalBoss_FSM stateMachine) : base("dead", stateMachine)
    {
        _fbsm = stateMachine;
    }
    // Start is called before the first frame update
    public override void Enter()
    {
        base.Enter();
        
        GameObject.Find("FinalBossUITrigger").SetActive(false); //disable the collider that locks in the player

        _fbsm.finalBossAnim.Play("dead"); //play dead anim
        _fbsm.fbm.shouldFlip = false;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (_fbsm.finalBossAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.6f)
            {
                GameObject.Destroy(GameObject.Find("Final Boss Health Bar"));
            }
    }

}
