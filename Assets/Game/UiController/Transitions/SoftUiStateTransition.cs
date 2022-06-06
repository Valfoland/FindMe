
using Frameworks.StateMachine;
using Game.UiController.Windows;

namespace Game.UiController.Transitions
{
    public class SoftUiStateTransition : UiStateTransition
    {
        public SoftUiStateTransition(WindowType windowType) : base(windowType)
        {
        }
        
        public override void TransitionTo(State previousState, State nextState)
        {
            nextState.OnEnter();
        }
    }
}
