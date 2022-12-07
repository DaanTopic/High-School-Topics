using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace XANFSM.Boss
{

    public class Boss : MonoBehaviour
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

        public void InitFSM()
        {
            fsm = new ZombieStateMachine();

            State state = new State(fsm);
            state.AddTransition(Transition.Lost, ZombieStateID.Idle);

            fsm.AddState(state);
        }
    }
}