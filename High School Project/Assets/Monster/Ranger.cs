using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace XANFSM.zombie
{

	public class Ranger : MonoBehaviour
	{
		private ZombieStateMachine fsm;
		public GameObject rock, hand;

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

        public void InitFSM() 
		{
			fsm = new ZombieStateMachine();

			FoundState foundState = new FoundState(fsm);
			foundState.AddTransition(Transition.CloseToPlayer, ZombieStateID.Attack);
			foundState.AddTransition(Transition.Lost, ZombieStateID.Idle);

			IdleState idleState = new IdleState(fsm);
			idleState.AddTransition(Transition.Found, ZombieStateID.Chase);
			idleState.AddTransition(Transition.Patrol, ZombieStateID.Patrol);

			PatrolState patrolState = new PatrolState(this.gameObject, fsm);
			patrolState.AddTransition(Transition.Found, ZombieStateID.Chase);

			RangeAttackState rangeAttackState = new RangeAttackState(fsm);
			rangeAttackState.AddTransition(Transition.Found, ZombieStateID.Chase);

			fsm.AddState(idleState);
			fsm.AddState(foundState);
			fsm.AddState(rangeAttackState);
			fsm.AddState(patrolState);
		}
		void StartAttack()
        {
            Instantiate(rock, hand.transform.position, Quaternion.identity);
		}
		void EndAttack(){}
	}	
}	