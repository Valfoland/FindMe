using Game.BusinessLogic.Descriptions;
using Game.UiController.StateController;

namespace Game.UiController.Transitions
{
    public class UiStateTransitionFactory
    {
        public void SetTransition(UiState previousState, UiState currentState, UiTransitionDescription transitionDescription)
        {
            UiStateTransition _ = transitionDescription.TransitionType switch
            {
                TransitionType.Hard => new HardUiStateTransition(previousState, currentState),
                TransitionType.Soft => new SoftUiStateTransition(previousState, currentState),
                _ => new HardUiStateTransition(previousState, currentState)
            };
        }
    }
}
