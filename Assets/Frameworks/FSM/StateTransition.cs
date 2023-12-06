using System;
using System.Collections.Generic;
using System.Linq;


namespace Frameworks.FSM
{
    public class StateTransition
    {
        private readonly StateBase _fromState;
        private readonly StateBase _toState;
        private readonly IReadOnlyCollection<Func<bool>> _predicates;


        public StateTransition(StateBase fromState, StateBase toState,
            IReadOnlyCollection<Func<bool>> predicates)
        {
            _fromState = fromState;
            _toState = toState;
            _predicates = predicates;
        }


        public void Transit(Action<StateBase> onCompleted)
        {
            if (!Check())
            {
                return;
            }

            _fromState.OnExit();
            _toState.OnEnter();
            onCompleted?.Invoke(_toState);
        }


        public bool Check()
        {
            return _predicates == null || _predicates.All(predicate => predicate());
        }
    }
}