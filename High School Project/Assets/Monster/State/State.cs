using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace XANFSM.Boss
{

    public class State : ZombieState
    {
        public State(ZombieStateMachine zombieStateMachine) : base(zombieStateMachine)
        {
            mStateID = ZombieStateID.Idle;
        }

        public override void Act(GameObject npc)
        {
            //Todo
        }

        public override void Reason(GameObject npc)
        {
            //change State
            if (true)
            {
                Machine.PerformTransition(Transition.Lost);
            }
        }
    }
}