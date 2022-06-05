using Game.UiController.StateController;

namespace Game.UiController.Transitions
{
    public class HardUiStateTransition : UiStateTransition
    {
        public HardUiStateTransition(UiState previousState, UiState currentState) : base(previousState, currentState)
        {
            
        }

        protected override void SetTransition()
        {
            previousState.Hide();
            currentState.Show();
        }
    }
}
