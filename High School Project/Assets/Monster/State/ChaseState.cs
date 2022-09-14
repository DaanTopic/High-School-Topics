using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace XANFSM.zombie
{

    public class ChaseState : ZombieState
    {
        GameObject player;
        NavMeshAgent navAgent;
        Animator anim;

        public ChaseState(ZombieStateMachine zombieStateMachine) : base(zombieStateMachine)
        {
            mStateID = ZombieStateID.Chase;
            player = GameObject.FindWithTag("Player");
        }

        public override void Act(GameObject npc)
        {
            anim = npc.GetComponent<Animator>();
            anim.SetFloat("WalkSpeed", 1f);
            navAgent = npc.GetComponent<NavMeshAgent>();
            navAgent.isStopped = false;
            navAgent.destination = player.transform.position;
        }

        public override void Reason(GameObject npc)
        {
            if (Vector3.Distance(player.transform.position, npc.transform.position) > 15)
            {
                Machine.PerformTransition(Transition.Lost);
            }
            if (Vector3.Distance(player.transform.position, npc.transform.position) < 1.5f)
            {
                Machine.PerformTransition(Transition.CloseToPlayer);
            }
        }
    }
}