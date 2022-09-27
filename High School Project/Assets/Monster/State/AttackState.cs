using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace XANFSM.zombie
{

    public class AttackState : ZombieState
    {
        GameObject player;
        NavMeshAgent navAgent;
        Animator anim;
        AnimatorStateInfo animInfo;

        public AttackState(ZombieStateMachine zombieStateMachine) : base(zombieStateMachine)
        {
            mStateID = ZombieStateID.Attack;
            player = GameObject.FindWithTag("Player");
        }

        public override void Act(GameObject npc)
        {
            navAgent = npc.GetComponent<NavMeshAgent>();
            navAgent.SetDestination(player.transform.position);

            anim = npc.GetComponent<Animator>();
            animInfo = anim.GetCurrentAnimatorStateInfo(0);
        }

        public override void Reason(GameObject npc)
        {
            if ((animInfo.normalizedTime >= 1.0f) && (animInfo.IsName("Attack")))
            {
                if (Vector3.Distance(player.transform.position, npc.transform.position) < 5)
                {
                    anim.SetBool("Attack", false);
                    anim.SetBool("Chase", true);
                    Machine.PerformTransition(Transition.Found);
                }
                if (Vector3.Distance(player.transform.position, npc.transform.position) >= 5)
                {
                    anim.SetBool("Attack", false);
                    anim.SetBool("Idle", true);
                    Machine.PerformTransition(Transition.Lost);
                }
            }
        }
    } 
}