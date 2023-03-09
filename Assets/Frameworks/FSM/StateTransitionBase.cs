using System;
using System.Collections.Generic;


namespace Frameworks.FSM
{
    public abstract class StateTransitionBase
    {
        public string TransitionTag { get; private set; }
        protected readonly StateBase fromState;
        protected readonly StateBase toState;

        public abstract void Transit(Action<StateBase> onCompleted);


        protected StateTransitionBase(string transitionTag, StateBase fromState, StateBase toState)
        {
            TransitionTag = transitionTag;
            this.fromState = fromState;
            this.toState = toState;
        }
    }
}