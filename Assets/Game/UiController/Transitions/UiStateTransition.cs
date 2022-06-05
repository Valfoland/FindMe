using Game.UiController.StateController;

namespace Game.UiController.Transitions
{
    public abstract class UiStateTransition
    {
        protected UiState previousState;
        protected UiState currentState;
        
        protected abstract void SetTransition();

        protected UiStateTransition(UiState previousState, UiState currentState)
        {
            this.previousState = previousState;
            this.currentState = currentState;
        }
    }
}
