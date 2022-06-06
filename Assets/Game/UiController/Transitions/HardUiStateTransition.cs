using Frameworks.StateMachine;
using Game.UiController.Windows;

namespace Game.UiController.Transitions
{
    public class HardUiStateTransition : UiStateTransition
    {
        public HardUiStateTransition(WindowType windowType) : base(windowType)
        {
        }

        public override void TransitionTo(State previousState, State nextState)
        {
            previousState.OnExit();
            nextState.OnEnter();
        }
    }
}
