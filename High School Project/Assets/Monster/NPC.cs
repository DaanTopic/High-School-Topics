using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace XANFSM.zombie
{

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

        private void FixedUpdate()
        {
			GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        void InitFSM() {
			fsm = new ZombieStateMachine();

			ChaseState chaseState = new ChaseState(fsm);
			chaseState.AddTransition(Transition.CloseToPlayer, ZombieStateID.Attack);
			chaseState.AddTransition(Transition.Lost, ZombieStateID.Idle);

			IdleState idleState = new IdleState(fsm);
			idleState.AddTransition(Transition.Found, ZombieStateID.Chase);
			idleState.AddTransition(Transition.Patrol, ZombieStateID.Patrol);

			PatrolState patrolState = new PatrolState(fsm);
			patrolState.AddTransition(Transition.Found, ZombieStateID.Chase);

			AttackState attackState = new AttackState(fsm);
			attackState.AddTransition(Transition.Lost, ZombieStateID.Idle);
			attackState.AddTransition(Transition.Found, ZombieStateID.Chase);

			fsm.AddState(idleState);
			fsm.AddState(chaseState);
			fsm.AddState(attackState);
			fsm.AddState(patrolState);
		}
	}	
}