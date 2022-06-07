using System;
using System.Collections.Generic;

namespace Frameworks.StateMachine
{
    public class StateContext
    {
        private Dictionary<Type, IStateTransitionData> _transitions = new Dictionary<Type, IStateTransitionData>();

        public void AddTransition(IStateTransitionData transitionData)
        {
            if (!_transitions.ContainsKey(transitionData.GetType()))
            {
                _transitions.Add(transitionData.GetType(), transitionData);
            }
        }

        public IStateTransitionData GetTransition(IStateTransitionData transitionData)
        {
            return _transitions[transitionData.GetType()];
        }
    }
}
