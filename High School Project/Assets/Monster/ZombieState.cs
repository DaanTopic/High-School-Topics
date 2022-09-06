using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieStateID
{
	None = 0,
	Idle,
	Chase
}

public enum Transition
{
	None,
	Lost,
	Found
}

namespace XANFSM { 
	public abstract class ZombieState
	{
		protected ZombieStateID mStateID; 
		public ZombieStateID MStateID { get { return mStateID; } }
 
		protected Dictionary<Transition, ZombieStateID> map = new Dictionary<Transition, ZombieStateID>();
		
		protected ZombieStateMachine mZombieStateMachine;
 
		public ZombieState(ZombieStateMachine zombieStateMachine) {
			mZombieStateMachine = zombieStateMachine;
		}
 
		public void AddTransition(Transition trans, ZombieStateID id)
        {
            if (trans == Transition.None)
            {
				Debug.LogError(GetType()+ "/AddTransition()/ transition is None");
				return;
			}
			if (id == ZombieStateID.None)
			{
				Debug.LogError(GetType() + "/AddTransition()/ stateId is None");
				return;
			}
			if (map.ContainsKey(trans))
			{
				Debug.LogError(GetType() + "/AddTransition()/ transition map has already existed, transition = " + trans);
				return;
			}
 
			map.Add(trans, id);
		}
 
		public void DeleteTransition(Transition trans)
		{
			if (trans == Transition.None)
			{
				Debug.LogError(GetType() + "/DeleteTransition()/ transition is None");
				return;
			}
		
			if (map.ContainsKey(trans)== false)
			{
				Debug.LogError(GetType() + "/DeleteTransition()/ transition map has not  existed, transition = " + trans);
				return;
			}
 
			map.Remove(trans);
		}

		public ZombieStateID GetStateWithTransition(Transition trans) {
            if (map.ContainsKey(trans))
            {
				return map[trans];
            }

			return ZombieStateID.None;
		}
 
		public virtual void DoBeforeEntering(){}
		public virtual void DoAfterLeaving(){}
		public abstract void Act(GameObject npc);
		public abstract void Reason(GameObject npc);
	}
}