using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace XANFSM { 
	public class ZombieStateMachine 
	{
		private Dictionary<ZombieStateID, ZombieState> statesDict = new Dictionary<ZombieStateID, ZombieState>();
		private ZombieStateID mCurrentStateID;
		private ZombieState mCurrentFSMState;
		public void DoUpdate(GameObject npc)
		{
			mCurrentFSMState.Act(npc);
			mCurrentFSMState.Reason(npc);
		}
		public void AddState(ZombieState fsmState) {
            if (fsmState == null)
            {
				Debug.LogError(GetType() + "/AddState()/ fsmState is null");
				return;
			}
 
            if (statesDict.ContainsKey(fsmState.MStateID))
            {
				Debug.LogError(GetType() + "/AddState()/ statesDict had already existed, fsmState.StateID = " + fsmState.MStateID);
				return;
			}
 
			if (mCurrentFSMState == null)
			{
				mCurrentFSMState = fsmState;
				mCurrentStateID = fsmState.MStateID;
			}
 
			statesDict.Add(fsmState.MStateID, fsmState);
		}

		public void DeleteState(ZombieStateID stateID)
		{
			if (stateID == ZombieStateID.None)
			{
				Debug.LogError(GetType() + "/DeleteState()/ stateID is None");
				return;
			}
 
 
			if (statesDict.ContainsKey(stateID) == false)
			{
				Debug.LogError(GetType() + "/DeleteState()/ statesDict had not existed, StateID = " + stateID);
				return;
			}
 
			
 
			statesDict.Remove(stateID);
		}

		public void PerformTransition(Transition trans) {
            if (trans == Transition.None)
            {
				Debug.LogError(GetType() + "/PerformTransition()/ trans is None" );
				return;
			}
			ZombieStateID stateID = mCurrentFSMState.GetStateWithTransition(trans);
            if (stateID == ZombieStateID.None)
            {
				Debug.LogWarning(GetType() + "/PerformTransition()/ stateID form GetOutputState(trans)  is None");
				return;
			}
 
            if (statesDict.ContainsKey(stateID) == false)
            {
				Debug.LogError(GetType() + "/PerformTransition()/ statesDict had not stateID，StateID = " + stateID);
				return;
			}
 
            if (mCurrentFSMState != null)
            {
				mCurrentFSMState.DoAfterLeaving();
            }
 
			ZombieState state = statesDict[stateID];
			mCurrentFSMState = state;
			mCurrentStateID = stateID;
 
			if (mCurrentFSMState != null)
			{
				mCurrentFSMState.DoBeforeEntering();
			}
		}
	}
}