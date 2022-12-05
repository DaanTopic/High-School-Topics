using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace XANFSM.zombie
{

    public class DeadState : ZombieState
    {
        Animator anim;

        public DeadState(ZombieStateMachine zombieStateMachine) : base(zombieStateMachine)
        {
            mStateID = ZombieStateID.Dead;
        }

        public override void Act(GameObject npc)
        {
            anim = npc.GetComponent<Animator>();
            anim.SetBool("Patrol", false);
            anim.SetBool("Chase", false);
            anim.SetBool("Attack", false);
            anim.SetBool("Idle", true);
        }

        public override void Reason(GameObject npc)
        {
            Machine.PerformTransition(Transition.Lost);
        }
    }
}