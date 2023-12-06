using Basement.OEPFramework.UnityEngine._Base;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Frameworks.FSM
{
    public abstract class StateBase : DroppableItemBase
    {
        public abstract string Id { get; }


        public event Action OnEnterState;
        
        public event Action OnExitState;

        public event Action OnFinishState; 


        public readonly List<StateTransition> stateTransitions = new();
        
        

        public void AddTransition(StateBase stateBase, params Func<bool>[] predicates)
        {
            stateTransitions.Add(new StateTransition(this, stateBase, predicates.ToList()));
        }


        public void AddTransition(StateBase stateBase)
        {
            stateTransitions.Add(new StateTransition(this, stateBase, null));
        }

        public virtual void OnEnter()
        {
            OnEnterState?.Invoke();
        }
        
        public virtual void OnExit()
        {
            OnExitState?.Invoke();
        }

        protected void FinishState()
        {
            OnFinishState?.Invoke();
        }
        
        public override void Drop()
        {
            OnEnterState = null;
            OnExitState = null;
            OnFinishState = null;

            base.Drop();
        }
    }
}