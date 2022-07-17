
using System.Collections.Generic;
using Frameworks.OEPFramework.UnityEngine.Behaviour;
using Frameworks.OEPFramework.UnityEngine.Loop;

namespace Frameworks.StateMachine
{
    public abstract class State : LoopBehaviour
    {
        public string StateId { get; }
        public bool StateInitialized { get; private set; }
        public List<IStateTransition> Transitions { get; } = new();
        public IStateAction CurrentStateAction { get; private set; }

        protected StateController Parent { get; private set; }
        protected abstract IStateAction GetStateAction(string stateId, IStateTransitionData transitionsData);

        private readonly IStateTransitionData _transitionsData;

        protected State(StateController parent, string stateId, IStateTransitionData transitionsData)
        {
            Parent = parent;
            StateId = stateId;

            _transitionsData = transitionsData;
        }

        public void Enter()
        {
            if (StateInitialized) return;

            StateInitialized = true;

            OnEnter();
            LoopOn(Loops.UPDATE, Update);
        }

        public void Exit()
        {
            OnExit();
            Drop();
        }

        protected virtual void OnEnter()
        {
            CurrentStateAction = GetStateAction(StateId, _transitionsData);
            CurrentStateAction.SetTransitionAction(OnActionExit);
            CurrentStateAction.Enter();
        }

        protected virtual void Update()
        {

        }

        protected virtual void OnExit()
        {
            CurrentStateAction.Exit();
            CurrentStateAction = null;

            StateInitialized = false;
        }

        protected virtual void DoTransition(string stateId)
        {
            Parent.DoTransition(stateId);
        }

        public void AddTransition(IStateTransition stateTransition)
        {
            Transitions.Add(stateTransition);
        }

        private void OnActionExit(string toStateTransition)
        {
            DoTransition(toStateTransition);
        }
    }
}
