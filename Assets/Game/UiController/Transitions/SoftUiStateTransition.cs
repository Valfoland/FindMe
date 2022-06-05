using Game.UiController.StateController;

namespace Game.UiController.Transitions
{
    public class SoftUiStateTransition : UiStateTransition
    {
        public SoftUiStateTransition(UiState previousState, UiState currentState) : base(previousState, currentState)
        {
            
        }

        protected override void SetTransition()
        {
            currentState.Show();
        }
    }
}
