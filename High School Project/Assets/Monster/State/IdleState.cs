using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
namespace XANFSM.zombie
{ 
 
	public class IdleState : ZombieState
    {
        GameObject player;
        NavMeshAgent navAgent;
        Animator anim;
        float AiTimes = 0f;

        public IdleState(ZombieStateMachine zombieStateMachine) : base(zombieStateMachine)
        {
            mStateID = ZombieStateID.Idle;
            player = GameObject.FindWithTag("Player");
        }

        public override void Act(GameObject npc)
        {
            navAgent = npc.GetComponent<NavMeshAgent>();
            anim = npc.GetComponent<Animator>();
            anim.SetFloat("WalkSpeed", 0f);
            navAgent.isStopped = true;

            UpdateTimes();
        }

        public override void Reason(GameObject npc)
        {
            if (Vector3.Distance(player.transform.position, npc.transform.position) < 5)
            {
                Machine.PerformTransition(Transition.Found);
            }
            if (AiTimes > 1f)
            {
                Machine.PerformTransition(Transition.Patrol);
            }
        }
        private void UpdateTimes()
        {
            AiTimes += 0.01f;
        }
    }
}