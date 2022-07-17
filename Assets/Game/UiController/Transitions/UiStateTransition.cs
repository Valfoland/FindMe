using Frameworks.StateMachine;
using Game.BusinessLogic.Descriptions;
using Game.Data.BusinessLogic.Descriptions.UiMapDescription;

namespace Game.UiController.Transitions
{
    public abstract class UiStateTransition : IStateTransition
    {
        public State From { get; }
        public State To { get; }
        public UiTransitionDescription Description { get; private set; }
        
        public abstract void TransitionTo();

        protected UiStateTransition(UiTransitionDescription description)
        {
            Description = description;
        }
    }
}
