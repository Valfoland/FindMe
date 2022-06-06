using System;
using System.Collections.Generic;

namespace Frameworks.StateMachine
{
    public class StateContext
    {
        private Dictionary<Type, IStateTransition> _transitions = new Dictionary<Type, IStateTransition>();

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
