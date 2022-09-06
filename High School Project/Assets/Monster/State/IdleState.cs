using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace XANFSM.Test { 
 
	public class IdleState : ZombieState
    {
        GameObject player;
        public IdleState(ZombieStateMachine zombieStateMachine) : base(zombieStateMachine)
        {
            mStateID = ZombieStateID.Idle;
            player = GameObject.FindWithTag("Player");
        }

        public override void Act(GameObject npc)
        {
            npc.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        public override void Reason(GameObject npc)
        {
            if (Vector3.Distance(player.transform.position, npc.transform.position) < 5)
            {
                mZombieStateMachine.PerformTransition(Transition.Found);
            }
        }
    }
}