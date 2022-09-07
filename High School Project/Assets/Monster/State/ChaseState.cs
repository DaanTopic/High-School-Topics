using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace XANFSM.Test
{

    public class ChaseState : ZombieState
    {
        GameObject player;
        NavMeshAgent navAgent;

        public ChaseState(ZombieStateMachine zombieStateMachine) : base(zombieStateMachine)
        {
            mStateID = ZombieStateID.Chase;
            player = GameObject.FindWithTag("Player");
        }

        public override void Act(GameObject npc)
        {
            navAgent = npc.GetComponent<NavMeshAgent>();
            navAgent.isStopped = false;
            navAgent.destination = player.transform.position;
        }

        public override void Reason(GameObject npc)
        {
            if (Vector3.Distance(player.transform.position, npc.transform.position) > 15)
            {
                mZombieStateMachine.PerformTransition(Transition.Lost);
            }
        }
    }
}