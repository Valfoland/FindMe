using System;
using System.Collections.Generic;


namespace Frameworks.FSM
{
    public class PredicatedStateTransition : StateTransitionBase
    {
        private readonly List<Func<bool>> _predicates;
    
        public PredicatedStateTransition(string transitionTag, StateBase fromState, StateBase toState, List<Func<bool>> predicates) : base(transitionTag, fromState, toState)
        {
            _predicates = predicates;
        }

        public override void Transit(Action<StateBase> onCompleted)
        {
            if (!Check()) return;
            
            fromState.OnExit();
            toState.OnEnter();
            onCompleted?.Invoke(toState);
        }
        
        protected bool Check()
        {
            foreach (var predicate in _predicates)
            {
                if (predicate() == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
