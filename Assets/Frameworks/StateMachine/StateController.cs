using System;

namespace Frameworks.StateMachine
{
    public abstract class StateController
    {
        protected State CurrentState { get; private set; }

        protected abstract void AddTransitions();
        protected abstract void RemoveTransitions();
        protected abstract State GetNextState();
        
        protected virtual void SwitchState(IStateTransition transition)
        {
            var previousState = CurrentState;
            DetachTransitionEvent();

            CurrentState = GetNextState();
            AttachTransitionEvent();
            
            transition.TransitionTo(previousState, CurrentState);
        }

        private void AttachTransitionEvent()
        {
            CurrentState.onNeedUpdateState += SwitchState;
        }

        private void DetachTransitionEvent()
        {
            CurrentState.onNeedUpdateState -= SwitchState;
        }
    }
}
