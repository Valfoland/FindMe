using Game.BusinessLogic.Descriptions;
using Game.BusinessLogic.Utils;
using Game.UiController.Windows;

namespace Game.UiController.StateController
{
    public class UiStateController
    {
        private readonly UiMapDescriptionCollection _uiCollection;
        private readonly UiStateTransitionFactory _transitionFactory;
            
        private UiState _currentState;

        public UiStateController()
        {
            _uiCollection = GameManager.context.GetChild<UiMapDescriptionCollection>(DataUtil.Entities.UiMap);
            _transitionFactory = new UiStateTransitionFactory();
        }

        public void SetNewState(WindowType windowType)
        {
            _currentState = new UiState(_uiCollection.GetChild(windowType.ToString()));
            AttachTransitionEvent();
        }

        private void SwitchState(UiTransitionDescription transitionDescription)
        {
            var previousState = _currentState;
            DetachTransitionEvent();
            
            _currentState = new UiState(_uiCollection.GetChild(transitionDescription.DestinationWindow.ToString()));
            AttachTransitionEvent();
            
            _transitionFactory.SetTransition(previousState, _currentState, transitionDescription);
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
