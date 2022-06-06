using System;
using Frameworks.StateMachine;
using Game.UiController.Windows;

namespace Game.UiController.Transitions
{
    public abstract class UiStateTransition : IStateTransition
    {
        public WindowType WindowType { get; private set; }

        protected UiStateTransition(WindowType windowType)
        {
            WindowType = windowType;
        }

        public virtual void TransitionTo(State previousState, State nextState)
        {
            throw new NotImplementedException();
        }

        public virtual T GetTransitionData<T>()
        {
            throw new NotImplementedException();
        }
    }
}
