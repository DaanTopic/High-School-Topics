using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace XANFSM.zombie
{

    public class PatrolState : ZombieState
    {
        GameObject player;
        NavMeshAgent navAgent;
        Animator anim;
        float PatrolRange = 5f, AiTimes = 0f;

        public PatrolState(ZombieStateMachine zombieStateMachine) : base(zombieStateMachine)
        {
            mStateID = ZombieStateID.Patrol;
            player = GameObject.FindWithTag("Player");
        }

        public override void Act(GameObject npc)
        {
            anim = npc.GetComponent<Animator>();
            navAgent = npc.GetComponent<NavMeshAgent>();
            navAgent.isStopped = true;

            AiTimes += 0.01f;
            if (AiTimes > 1f)
            {
                float AIx = Random.Range(-PatrolRange, PatrolRange);
                float AIz = Random.Range(-PatrolRange, PatrolRange);
                Vector3 ran = new Vector3(AIx, 0, AIz);
                Quaternion rotation = Quaternion.LookRotation(ran - npc.transform.position);
                npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation, rotation, Time.deltaTime * 10);
                npc.transform.Translate(Vector3.forward * Time.deltaTime * 3);
                AiTimes = 0f;
            }
        }

        public override void Reason(GameObject npc)
        {
            if (Vector3.Distance(player.transform.position, npc.transform.position) < 5)
            {
                anim.SetBool("Patrol", false);
                anim.SetBool("Chase", true);
                Machine.PerformTransition(Transition.Found);
            }
        }
    }
}