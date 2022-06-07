using Frameworks.StateMachine;
using Game.BusinessLogic.Descriptions;


namespace Game.UiController.Transitions
{
    public class SoftUiStateTransition : UiStateTransition
    {
        public SoftUiStateTransition(UiTransitionDescription description) : base(description)
        {
        }

        public override void TransitionTo(State previousState, State nextState, IStateTransitionData data)
        {
            nextState.OnEnter();
        }
    }
}
