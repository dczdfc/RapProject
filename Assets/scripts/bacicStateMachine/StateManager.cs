using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public abstract class StateManager<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, BaceState<EState>> States = new Dictionary<EState, BaceState<EState>>();
    protected BaceState<EState> CurrentState;


    protected bool IsTransitioningState = false;
    public UnityEvent<EState> TransitionEvent;
    
    
    void Start(){
        CurrentState.EnterState();
    }
    void Update(){
        EState nextStateKey = CurrentState.GetNextState();

        if (!IsTransitioningState && nextStateKey.Equals(CurrentState.StateKey))
        {
            CurrentState.UpdateState();
        }else if(!IsTransitioningState)
        {
            TransitionToState(nextStateKey);
        }
    }
    void FixedUpdate(){
        if (!IsTransitioningState)
        {
            CurrentState.FixedUpdateState();
        }
        
    }
    public void TransitionToState(EState stateKey)
    {
        IsTransitioningState = true;
        CurrentState.ExitState();
        CurrentState = States[stateKey];
        CurrentState.EnterState();
        IsTransitioningState = false;
        TransitionEvent.Invoke(stateKey);
    }

}
