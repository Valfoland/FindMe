using Frameworks.StateMachine;
using Game.BusinessLogic.Descriptions;

namespace Game.UiController.Transitions
{
    public abstract class UiStateTransition : IStateTransition
    {
        public UiTransitionDescription Description { get; private set; }
        
        public abstract void TransitionTo(State previousState, State nextState);

        protected UiStateTransition(UiTransitionDescription description)
        {
            Description = description;
        }

        
    }
}
