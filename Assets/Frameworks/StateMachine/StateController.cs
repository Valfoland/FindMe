using System.Collections.Generic;

namespace Frameworks.StateMachine
{
    public abstract class StateController
    {
        protected IStateTransitionData TransitionMap { get; private set; }
        protected State CurrentState { get; private set; }

        protected abstract State GetState(string stateId);
        protected abstract bool TryGetTransition(string fromStateId, string toStateId, out IStateTransition transition);

        private Dictionary<string, State> _states = new();

        protected StateController(IStateTransitionData transitionMap)
        {
            TransitionMap = transitionMap;
        }
        
        public void SwitchState(string toStateId)
        {
            var previousState = CurrentState;
            CurrentState = GetCachedState(toStateId);
            
            if (previousState != null && TryGetTransition(previousState.StateId, CurrentState.StateId, out var transition))
            {
                transition.TransitionTo(previousState, CurrentState);
            }
            else
            {
                DefaultTransition(previousState, CurrentState);
            }
        }

        private State GetCachedState(string stateId)
        {
            var hasState = _states.ContainsKey(stateId);

            if (!hasState)
            {
                var state = GetState(stateId);
                _states.Add(stateId, state);

                return state;
            }

            return _states[stateId];
        }

        public void RemoveState(string stateId)
        {
            _states.Remove(stateId);
        }

        private void DefaultTransition(State previousState, State currentState)
        {
            previousState?.OnExit();
            currentState.OnEnter();
        }
    }
}
