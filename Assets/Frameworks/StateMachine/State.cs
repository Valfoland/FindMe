
using System;
using System.Collections.Generic;

namespace Frameworks.StateMachine
{
    public abstract class State
    {
        protected string StateId { get; private set; }
        protected IStateAction StateAction { get; private set; }
        protected IEnumerable<KeyValuePair<string, IStateTransitionData>> TransitionsData { get; }

        protected abstract IStateAction GetStateAction(string stateId, IEnumerable<KeyValuePair<string, IStateTransitionData>> transitionsData);

        protected readonly StateController stateController;

        protected State(StateController stateController, string stateId, IEnumerable<KeyValuePair<string, IStateTransitionData>> transitionsData)
        {
            this.stateController = stateController;
            
            TransitionsData = transitionsData;
            StateId = stateId;
        }

        public virtual void OnEnter()
        {
            StateAction = GetStateAction(StateId, TransitionsData);
            StateAction.Show(OnSetTransition);
        }

        public virtual void OnExit()
        {
            StateAction.Hide();
            StateAction = null;
        }

        private void OnSetTransition(IStateTransitionData stateTransitionData)
        {
            stateController.SwitchState(stateTransitionData);
        }
    }
}
