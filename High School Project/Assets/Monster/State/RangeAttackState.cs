using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace XANFSM.zombie
{

    public class RangeAttackState : ZombieState
    {
        GameObject player;
        NavMeshAgent navAgent;
        Animator anim;
        AnimatorStateInfo animInfo;

        public RangeAttackState(ZombieStateMachine zombieStateMachine) : base(zombieStateMachine)
        {
            mStateID = ZombieStateID.Attack;
            player = GameObject.FindWithTag("Player");
        }

        public override void Act(GameObject npc)
        {
            navAgent = npc.GetComponent<NavMeshAgent>();
            navAgent.isStopped = true;
            npc.GetComponent<Transform>().LookAt(player.transform);

            anim = npc.GetComponent<Animator>();
            animInfo = anim.GetCurrentAnimatorStateInfo(0);
        }

        public override void Reason(GameObject npc)
        {
            if ((animInfo.normalizedTime >= 1.0f) && (animInfo.IsName("Attack")))
            {
                if (Vector3.Distance(player.transform.position, npc.transform.position) > 12)
                {
                    anim.SetBool("Attack", false);
                    anim.SetBool("Chase", true);
                    Machine.PerformTransition(Transition.Found);
                }
            }
        }
    } 
}