using Frameworks.StateMachine;
using Game.Data.BusinessLogic.Descriptions.UiMapDescription;

namespace Game.UiController.Transitions
{
    public class HardUiStateTransition : UiStateTransition
    {
        public HardUiStateTransition(UiTransitionDescription description) : base(description)
        {
        }

        public override void TransitionTo()
        {
            From.Exit();
            To.Enter();
        }
    }
}
