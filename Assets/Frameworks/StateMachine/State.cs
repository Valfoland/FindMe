
using System;

namespace Frameworks.StateMachine
{
    public abstract class State
    {
        public event Action<IStateTransition> onNeedUpdateState;

        protected IStateAction StateAction { get; private set; }
        protected readonly StateContext context;
        
        protected abstract IStateAction GetStateAction();
        protected abstract IStateTransition GetTransition();
        
        protected State(StateContext context)
        {
            this.context = context;
        }

        public virtual void OnEnter()
        {
            StateAction = GetStateAction();
            StateAction.onSetTransition += OnSetTransition;
            StateAction.Show();
        }

        public virtual void OnExit()
        {
            StateAction.onSetTransition -= OnSetTransition;
            StateAction.Hide();
            StateAction = null;
        }

        protected virtual void OnSetTransition(IStateTransitionDecision stateTransitionDecision)
        {
            if (stateTransitionDecision.Check())
            {
                onNeedUpdateState?.Invoke(GetTransition());
            }
        }
    }
}
