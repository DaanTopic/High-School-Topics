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
        float PatrolRange = 15f, PatrolError = 1f, AIx, AIz;
        Vector3 home, setAI, ran;
        Mover mover;


        public PatrolState(GameObject npc, ZombieStateMachine zombieStateMachine) : base(zombieStateMachine)
        {
            mStateID = ZombieStateID.Patrol;
            player = GameObject.FindWithTag("Player");
            setAI = npc.transform.position;
            home = npc.transform.position;
        }

        public override void Act(GameObject npc)
        {
            anim = npc.GetComponent<Animator>();
            navAgent = npc.GetComponent<NavMeshAgent>();
            mover = npc.GetComponent<Mover>();
            if (Vector3.Distance(npc.transform.position, home) <= PatrolError)
            {
                AIx = Random.Range(-PatrolRange, PatrolRange);
                AIz = Random.Range(-PatrolRange, PatrolRange);
                ran = new Vector3(AIx, 0, AIz);
                home = setAI + ran;
            }
            mover.MoveTo(home, 1f);
        }

        public override void Reason(GameObject npc)
        {
            var events = GameObject.Find("GameRules").GetComponent<gamerules>().Events;
            if (Vector3.Distance(player.transform.position, npc.transform.position) < 5 || events)
            {
                anim.SetBool("Patrol", false);
                anim.SetBool("Chase", true);
                Machine.PerformTransition(Transition.Found);
            }
        }
    }
}