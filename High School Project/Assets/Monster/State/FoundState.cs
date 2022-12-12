using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace XANFSM.zombie
{

    public class FoundState : ZombieState
    {
        GameObject player;
        NavMeshAgent navAgent;
        Animator anim;

        public FoundState(ZombieStateMachine zombieStateMachine) : base(zombieStateMachine)
        {
            mStateID = ZombieStateID.Chase;
            player = GameObject.FindWithTag("Player");
        }

        public override void Act(GameObject npc)
        {
            anim = npc.GetComponent<Animator>();

            navAgent = npc.GetComponent<NavMeshAgent>();
            navAgent.speed = 3.5f;
            navAgent.isStopped = false;
            navAgent.SetDestination(player.transform.position);
        }

        public override void Reason(GameObject npc)
        {
            if ((Vector3.Distance(player.transform.position, npc.transform.position) > 15) /*&& !Events*/)
            {
                anim.SetBool("Chase", false);
                anim.SetBool("Idle", true);
                Machine.PerformTransition(Transition.Lost);
            }
            if (Vector3.Distance(player.transform.position, npc.transform.position) < 12)
            {
                anim.SetBool("Chase", false);
                anim.SetBool("Attack", true);
                Machine.PerformTransition(Transition.CloseToPlayer);
            }
        }
    }
}