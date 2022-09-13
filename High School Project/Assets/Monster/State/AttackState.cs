using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace XANFSM.zombie
{

    public class AttackState : ZombieState
    {
        NavMeshAgent navAgent;
        Animator animator;

        public AttackState(ZombieStateMachine zombieStateMachine) : base(zombieStateMachine)
        {
            mStateID = ZombieStateID.Attack;
        }

        public override void Act(GameObject npc)
        {
            animator = npc.GetComponent<Animator>();
            navAgent = npc.GetComponent<NavMeshAgent>();
        }

        public override void Reason(GameObject npc)
        {
            
        }
    }
}