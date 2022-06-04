using System;
using Game.BusinessLogic.Descriptions;
using Game.UiController.Windows.WindowsUi;

namespace Game.UiController.StateController
{
    public class UiState
    {
        public event Action<UiTransitionDescription> onSetTransition; 

        private readonly UiTransitionDescriptionCollection _transitionCollection;
        private readonly WindowBase _windowBase;
        
        public UiState(UiTransitionDescriptionCollection transitionCollection)
        {
            _transitionCollection = transitionCollection;
            _windowBase = new WindowBase(); //TODO должен быть WindowFactory
            
        }

        public void Show()
        {
            _windowBase.onSetTransition += OnSetTransition;
        }

        public void Hide()
        {
            _windowBase.onSetTransition -= OnSetTransition;
        }

        private void OnSetTransition(string transitionKey)
        {
            var transitionDescription = _transitionCollection.GetChild(transitionKey);
            onSetTransition?.Invoke(transitionDescription);
        }
    }
}
