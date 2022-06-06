using System;

namespace Frameworks.StateMachine
{
    public abstract class StateController
    {
        protected State CurrentState { get; private set; }

        protected abstract State GetState(Action<IStateTransition> onSetTransition, IStateTransition transition);

        public void SwitchState(IStateTransition transition)
        {
            var previousState = CurrentState;

            CurrentState = GetState(SwitchState, transition);

            transition.TransitionTo(previousState, CurrentState);
        }
    }
}
