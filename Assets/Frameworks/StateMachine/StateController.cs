using System;

namespace Frameworks.StateMachine
{
    public abstract class StateController
    {
        protected State CurrentState { get; private set; }

        protected abstract State GetState(Action<IStateTransitionData> onSetTransition, IStateTransitionData transitionData);
        protected abstract IStateTransition GetTransition();
        
        public void SwitchState(IStateTransitionData transitionData)
        {
            var previousState = CurrentState;

            CurrentState = GetState(SwitchState, transitionData);
            
            GetTransition().TransitionTo(previousState, CurrentState, transitionData);
        }
    }
}
