using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XANFSM.Test {

	public class NPC : MonoBehaviour
	{
		private ZombieStateMachine mFSMStateManager;

		void Start()
		{
			InitFSM();
		}

		void Update()
		{
			mFSMStateManager.DoUpdate(this.gameObject);
		}
 
		void InitFSM() {
			mFSMStateManager = new ZombieStateMachine();

			ChaseState chaseState = new ChaseState(mFSMStateManager);
			chaseState.AddTransition(Transition.Lost, ZombieStateID.Idle);

			IdleState idleState = new IdleState(mFSMStateManager);
			idleState.AddTransition(Transition.Found, ZombieStateID.Chase);

			mFSMStateManager.AddState(idleState);
			mFSMStateManager.AddState(chaseState);
		}
	}	
}