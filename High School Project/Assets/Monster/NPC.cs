using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace XANFSM.Test {

	public class NPC : MonoBehaviour
	{
        
        public Vector3 playerPosition;
        public NavMeshAgent navAgent;
		private ZombieStateMachine mFSMStateManager;

		void Start()
		{
			InitFSM();
            playerPosition = GameObject.FindWithTag("Player").transform.position;
            navAgent = GetComponent<NavMeshAgent>();
		}

		void Update()
		{
			mFSMStateManager.DoUpdate(this.gameObject);
		}
 
		void InitFSM() {
			mFSMStateManager = new ZombieStateMachine();
 
			IdleState idleState = new IdleState(mFSMStateManager);
			idleState.AddTransition(Transition.Lost, ZombieStateID.Idle);
 
			mFSMStateManager.AddState(idleState);
		}
	}	
}