using Game.BusinessLogic.Descriptions;
using Game.BusinessLogic.Utils;
using Game.UiController.Windows;

namespace Game.UiController.StateController
{
    public class UiStateController
    {
        private readonly UiMapDescriptionCollection _uiCollection;
        
        private UiState _currentState;

        public UiStateController()
        {
            _uiCollection = GameManager.context.GetChild<UiMapDescriptionCollection>(DataUtil.Entities.UiMap);
        }

        private void SwitchState(UiTransitionDescription transitionDescription)
        {
            HidePreviousState();
            ShowCurrentState(transitionDescription);
        }

        private void HidePreviousState()
        {
            _currentState.Hide();
            DetachTransitionEvent();
        }

        private void ShowCurrentState(UiTransitionDescription transitionDescription)
        {
            _currentState = new UiState(_uiCollection.GetChild(transitionDescription.DestinationWindow.ToString()));
            _currentState.Show();
            AttachTransitionEvent();
        }

        private void AttachTransitionEvent()
        {
            _currentState.onSetTransition += SwitchState;
        }

        private void DetachTransitionEvent()
        {
            _currentState.onSetTransition -= SwitchState;
        }
    }
}
