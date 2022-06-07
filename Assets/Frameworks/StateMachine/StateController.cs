using System;
using System.Collections.Generic;

namespace Frameworks.StateMachine
{
    public abstract class StateController
    {
        
        protected IEnumerable<KeyValuePair<string, IStateTransitionData>> TransitionMap { get; private set; }
        protected State CurrentState { get; private set; }

        protected abstract State GetState(string stateId);
        protected abstract IStateTransition GetTransition(string stateId);

        protected StateController(IEnumerable<KeyValuePair<string, IStateTransitionData>> transitionMap)
        {
            TransitionMap = transitionMap;
        }
        
        public void SwitchState(string stateId)
        {
            var previousState = CurrentState;
            CurrentState = GetState(stateId);
            
            GetTransition(stateId).TransitionTo(previousState, CurrentState);
        }
    }
}
