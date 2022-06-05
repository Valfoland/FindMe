using System;
using System.Collections.Generic;

namespace Frameworks.StateMachine
{
    public class StateContext
    {
        private Dictionary<Type, IStateTransitionDecision> _transitionDecisions = new Dictionary<Type, IStateTransitionDecision>();
        private Dictionary<Type, IStateTransition> _transitions = new Dictionary<Type, IStateTransition>();

        public void AddTransitionDecision(IStateTransitionDecision transitionDecision)
        {
            if (!_transitionDecisions.ContainsKey(transitionDecision.GetType()))
            {
                _transitionDecisions.Add(transitionDecision.GetType(), transitionDecision);
            }
            
        }

        public IStateTransitionDecision GetTransitionDecision(IStateTransitionDecision transitionDecision)
        {
            return _transitionDecisions[transitionDecision.GetType()];
        }
        
        public void AddTransition(IStateTransition transition)
        {
            if (!_transitions.ContainsKey(transition.GetType()))
            {
                _transitions.Add(transition.GetType(), transition);
            }
        }

        public IStateTransition GetTransition(IStateTransition transition)
        {
            return _transitions[transition.GetType()];
        }
    }
}
