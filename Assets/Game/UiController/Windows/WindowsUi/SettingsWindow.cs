using Game.BusinessLogic.Descriptions;
using Game.Data.BusinessLogic.Descriptions.UiMapDescription;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UiController.Windows.WindowsUi
{
    public class SettingsWindow : WindowBase
    {
        private const string CloseButton = "_CloseButton";

        private Button _closeButton;
        
        public SettingsWindow(UiTransitionDescriptionCollection uiTransitionDescriptionCollection, RectTransform parent,
            string prefabPath) : base(uiTransitionDescriptionCollection, prefabPath, parent)
        {
        }

        public override void Enter()
        {
            base.Enter();
            CreateUiMap();
            
            _closeButton = GetElementComponent<Button>(CloseButton);
            _closeButton.onClick.AddListener(OnCloseButtonClicked);
            gameObject.SetActive(true);
        }

        public override void Exit()
        {
            _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
            gameObject.SetActive(false);
            base.Exit();
        }
        
        private void OnCloseButtonClicked()
        {
            onSetTransition?.Invoke(WindowType.MainUi.ToString());
        }
    }
}
