using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
namespace XANFSM.Test { 
 
	public class IdleState : ZombieState
    {
        GameObject player;
        NavMeshAgent navAgent;

        public IdleState(ZombieStateMachine zombieStateMachine) : base(zombieStateMachine)
        {
            mStateID = ZombieStateID.Idle;
            player = GameObject.FindWithTag("Player");
        }

        public override void Act(GameObject npc)
        {
            navAgent = npc.GetComponent<NavMeshAgent>();
            navAgent.isStopped = true;
            navAgent.destination = npc.transform.position;
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