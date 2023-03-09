using System;


namespace Frameworks.FSM
{
    public sealed class DefaultStateTransition : StateTransitionBase
    {
        public DefaultStateTransition(string transitionTag, StateBase fromState, StateBase toState) : base(transitionTag, fromState, toState)
        {
        }

        public override void Transit(Action<StateBase> onCompleted)
        {
            fromState.OnExit();
            toState.OnEnter();
            
            onCompleted?.Invoke(toState);
        }
    }
}
