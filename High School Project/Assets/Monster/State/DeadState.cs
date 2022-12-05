using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
namespace XANFSM.zombie
{ 
 
	public class DeadState : ZombieState
    {
        NavMeshAgent navAgent;
        Animator anim;
        float AiTimes;

        public DeadState(ZombieStateMachine zombieStateMachine) : base(zombieStateMachine)
        {
            mStateID = ZombieStateID.Dead;
        }

        public override void Act(GameObject npc)
        {
            navAgent = npc.GetComponent<NavMeshAgent>();
            anim = npc.GetComponent<Animator>();
            navAgent.isStopped = true;

            UpdateTimes();
        }

        public override void Reason(GameObject npc)
        {
            anim.SetBool("Patrol", false);
            anim.SetBool("Chase", false);
            anim.SetBool("Attack", false);
            anim.SetBool("Idle", true);
            if (AiTimes > 1f)
            {
                Machine.PerformTransition(Transition.Lost);
            }
        }
        private void UpdateTimes()
        {
            AiTimes += Time.deltaTime;
        }
    }
}