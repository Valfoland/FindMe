using System;
using System.Collections.Generic;
using System.Linq;


namespace Frameworks.FSM
{
    public abstract class StateBase
    {
        public int Id { get; private set; }
        public string Tag { get; private set; }
        
        public event Action OnEnterEvent;
        public event Action OnExitEvent;
        
        public readonly List<StateTransitionBase> stateTransitions = new();

        public void AddCustomTransition(StateTransitionBase stateTransitionBase)
        {
            stateTransitions.Add(stateTransitionBase);
        }

        public void AddTransition(StateBase stateBase, string transitionTag, params Func<bool>[] predicates)
        {
            stateTransitions.Add(new PredicatedStateTransition(transitionTag, this, stateBase, predicates.ToList()));
        }

        public void AddTransition(StateBase stateBase, string transitionTag)
        {
            stateTransitions.Add(new DefaultStateTransition(transitionTag, this, stateBase));
        }

        public void RemoveTransition(string transitionTag)
        {
            var transition = stateTransitions.FirstOrDefault(t => t.TransitionTag == transitionTag);

            if (transition != null)
            {
                stateTransitions.Remove(transition);
            }
        }

        public virtual void OnEnter()
        {
            OnEnterEvent?.Invoke();
        }

        public virtual void OnExit()
        {
            OnExitEvent?.Invoke();
        }
    }
}