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
        float AiTimes;

        public IdleState(ZombieStateMachine zombieStateMachine) : base(zombieStateMachine)
        {
            mStateID = ZombieStateID.Idle;
            player = GameObject.FindWithTag("Player");
        }

        public override void Act(GameObject npc)
        {
            navAgent = npc.GetComponent<NavMeshAgent>();
            navAgent.isStopped = true;
            anim = npc.GetComponent<Animator>();
            anim.SetBool("Patrol", false);
            anim.SetBool("Chase", false);
            anim.SetBool("Attack", false);
            anim.SetBool("Idle", true);

            UpdateTimes();
        }

        public override void Reason(GameObject npc)
        {
            if (Vector3.Distance(player.transform.position, npc.transform.position) < 5)
            {
                anim.SetBool("Idle", false);
                anim.SetBool("Chase", true);
                Machine.PerformTransition(Transition.Found);
            }
            if (AiTimes > 1f)
            {
                anim.SetBool("Idle", false);
                anim.SetBool("Patrol", true);
                Machine.PerformTransition(Transition.Patrol);
                AiTimes = 0f;
            }
        }
        private void UpdateTimes()
        {
            AiTimes += Time.deltaTime;
        }
    }
}