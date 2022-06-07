
using System;
using System.Collections.Generic;

namespace Frameworks.StateMachine
{
    public abstract class State
    {

        protected IStateAction StateAction { get; private set; }
        protected IEnumerable<KeyValuePair<string, IStateTransitionData>> TransitionsData { get; }
        protected IStateTransitionData MainTransitionData { get; private set; }

        protected abstract IStateAction GetStateAction(IStateTransitionData mainTransitionData, IEnumerable<KeyValuePair<string, IStateTransitionData>> transitionsData);

        private readonly Action<IStateTransitionData> _onNeedUpdateState;

        protected State(Action<IStateTransitionData> onNeedUpdateState, IStateTransitionData mainTransitionData,
            IEnumerable<KeyValuePair<string, IStateTransitionData>> transitionsData)
        {
            _onNeedUpdateState = onNeedUpdateState;
            TransitionsData = transitionsData;
            MainTransitionData = mainTransitionData;
        }

        public virtual void OnEnter()
        {
            StateAction = GetStateAction(MainTransitionData, TransitionsData);
            StateAction.Show(OnSetTransition);
        }

        public virtual void OnExit()
        {
            StateAction.Hide();
            StateAction = null;
        }

        private void OnSetTransition(IStateTransitionData stateTransitionData)
        {
            _onNeedUpdateState?.Invoke(stateTransitionData);
        }
    }
}
