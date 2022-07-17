using System.Collections.Generic;
using UnityEngine;

namespace Frameworks.StateMachine
{
    public abstract class StateController : State
    {
        protected State CurrentState { get; private set; }

        private readonly Dictionary<string, List<IStateTransition>> _states = new();

        protected StateController(StateController parent, string stateId, IStateTransitionData transitionsData) : base(parent, stateId, transitionsData)
        {
        }
        
        protected void Setup(State[] states)
        {
            foreach (var state in states)
            {
                _states[StateId] = state.Transitions;
            }
        }

        protected override void DoTransition(string toStateId)
        {
            var contains = false;
            if (string.IsNullOrEmpty(toStateId))
            {
                foreach (var state in _states[CurrentState.StateId])
                {
                    if (state.To.StateId == toStateId)
                    {
                        state.TransitionTo();
                        CurrentState = state.To;
                        contains = true;
                    }
                }

                if (contains == false)
                {
                    if (Parent == null)
                    {
                        Debug.LogError("Can't find state with id: " + toStateId);
                        Finish();
                    }
                    else
                    {
                        DoTransition(toStateId);
                    }
                }
            }
            else
            {
                Finish();
            }
        }

        protected override void OnEnter()
        {
        }

        protected override void OnExit()
        {
        }

        protected virtual void Finish()
        {
            Exit();
        }
    }
}
