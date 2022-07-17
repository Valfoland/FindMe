using Frameworks.StateMachine;
using Game.BusinessLogic.Descriptions;
using Game.Data.BusinessLogic.Descriptions.UiMapDescription;


namespace Game.UiController.Transitions
{
    public class SoftUiStateTransition : UiStateTransition
    {
        public SoftUiStateTransition(UiTransitionDescription description) : base(description)
        {
        }

        public override void TransitionTo()
        {
            To.Enter();
        }
    }
}
