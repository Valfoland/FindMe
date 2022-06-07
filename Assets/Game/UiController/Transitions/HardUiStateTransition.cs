using Frameworks.StateMachine;
using Game.BusinessLogic.Descriptions;

namespace Game.UiController.Transitions
{
    public class HardUiStateTransition : UiStateTransition
    {
        public HardUiStateTransition(UiTransitionDescription description) : base(description)
        {
        }

        public override void TransitionTo(State previousState, State nextState, IStateTransitionData data)
        {
            previousState.OnExit();
            nextState.OnEnter();
        }
    }
}
