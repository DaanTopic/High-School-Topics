using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace XANFSM.zombie
{

    public class AttackState : ZombieState
    {
        GameObject player;
        Animator anim;
        AnimatorStateInfo animInfo;

        public AttackState(ZombieStateMachine zombieStateMachine) : base(zombieStateMachine)
        {
            mStateID = ZombieStateID.Attack;
            player = GameObject.FindWithTag("Player");
        }

        public override void Act(GameObject npc)
        {
            anim = npc.GetComponent<Animator>();
            animInfo = anim.GetCurrentAnimatorStateInfo(0);
            anim.SetBool("Attack", true);
        }

        public override void Reason(GameObject npc)
        {
            if ((animInfo.normalizedTime > 0.8f) && (animInfo.IsName("Attack")))
            {
                anim.SetBool("Attack", false);
                if (Vector3.Distance(player.transform.position, npc.transform.position) < 5)
                {
                    Machine.PerformTransition(Transition.Found);
                }
                if (Vector3.Distance(player.transform.position, npc.transform.position) > 15)
                {
                    Machine.PerformTransition(Transition.Lost);
                }
            }
        }
    }
}