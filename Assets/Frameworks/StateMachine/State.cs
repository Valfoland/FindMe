
using System;

namespace Frameworks.StateMachine
{
    public abstract class State
    {
        protected IStateAction StateAction { get; private set; }
        protected IStateTransition Transition { get; private set; }

        private readonly Action<IStateTransition> _onNeedUpdateState;

        protected abstract IStateAction GetStateAction(IStateTransition transition);

        protected State(Action<IStateTransition> onNeedUpdateState, IStateTransition transition)
        {
            _onNeedUpdateState = onNeedUpdateState;
            Transition = transition;
        }

        public virtual void OnEnter()
        {
            StateAction = GetStateAction(Transition);
            StateAction.Show(OnSetTransition);
        }

        public virtual void OnExit()
        {
            StateAction.Hide();
            StateAction = null;
        }

        private void OnSetTransition(IStateTransition stateTransition)
        {
            _onNeedUpdateState?.Invoke(stateTransition);
        }
    }
}
