using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
namespace XANFSM.Test { 
 
	public class IdleState : ZombieState
    {
        NavMeshAgent navAgent;
        float maxSpeed;
        Vector3 playerPosition;

        public IdleState(ZombieStateMachine zombieStateMachine) : base(zombieStateMachine)
        {
            maxSpeed = 3f;
            mStateID = ZombieStateID.Idle;
            playerPosition = GameObject.FindWithTag("Player").transform.position;
        }

        public override void Act(GameObject npc)
        {
            navAgent = npc.GetComponent<NavMeshAgent>();
            navAgent.speed = maxSpeed * 1 * Time.deltaTime;
            navAgent.Setdestination(playerPosition);
        }

        public override void Reason(GameObject npc)
        {
            mZombieStateMachine.PerformTransition(Transition.Lost);
        }
    }
}