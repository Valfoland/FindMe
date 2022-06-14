
namespace Frameworks.StateMachine
{
    public abstract class State
    {
        public string StateId { get; private set; }
        protected IStateAction CurrentStateAction { get; private set; }
        protected IStateTransitionData TransitionsData { get; }

        protected abstract IStateAction GetStateAction(string stateId, IStateTransitionData transitionsData);

        protected readonly StateController stateController;

        protected State(StateController stateController, string stateId, IStateTransitionData transitionsData)
        {
            this.stateController = stateController;
            
            TransitionsData = transitionsData;
            StateId = stateId;
        }

        public virtual void OnEnter()
        {
            if (CurrentStateAction != null) return;
            
            CurrentStateAction = GetStateAction(StateId, TransitionsData);
            CurrentStateAction.SetTransitionAction(OnSetTransition);
            CurrentStateAction.Show();
        }

        public virtual void OnExit()
        {
            CurrentStateAction.Hide();
            CurrentStateAction = null;

            stateController.RemoveState(StateId);
        }

        private void OnSetTransition(string toStateTransition)
        {
            stateController.SwitchState(toStateTransition);
        }
    }
}
