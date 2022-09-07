using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace XANFSM.Test {

	public class NPC : MonoBehaviour
	{
		private ZombieStateMachine fsm;

		void Start()
		{
			InitFSM();
        }

		void Update()
		{
			fsm.DoUpdate(this.gameObject);
		}
 
		void InitFSM() {
			fsm = new ZombieStateMachine();

			ChaseState chaseState = new ChaseState(fsm);
			chaseState.AddTransition(Transition.Lost, ZombieStateID.Idle);

			IdleState idleState = new IdleState(fsm);
			idleState.AddTransition(Transition.Found, ZombieStateID.Chase);

			fsm.AddState(idleState);
			fsm.AddState(chaseState);
		}
	}	
}