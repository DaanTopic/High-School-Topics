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

            navAgent = npc.GetComponent<NavMeshAgent>();
            navAgent.speed = 3.5f;
            navAgent.isStopped = false;
            navAgent.SetDestination(player.transform.position);
            
        }

        public override void Reason(GameObject npc)
        {
            var events = GameObject.Find("GameRules").GetComponent<gamerules>().Events;
            if ((Vector3.Distance(player.transform.position, npc.transform.position) > 15) && !events)
            {
                anim.SetBool("Chase", false);
                anim.SetBool("Idle", true);
                Machine.PerformTransition(Transition.Lost);
            }
            if (Vector3.Distance(player.transform.position, npc.transform.position) < 1.5f)
            {
                anim.SetBool("Chase", false);
                anim.SetBool("Attack", true);
                Machine.PerformTransition(Transition.CloseToPlayer);
            }
        }
    }
}