using Game.BusinessLogic.Descriptions;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UiController.Windows.WindowsUi
{
    public class MainUi : WindowBase
    {
        private const string SettingsButton = "_SettingsButton";
        private const string CloseButton = "_CloseButton";

        private Button _closeButton;
        private Button _settingsButton;
        
        public MainUi(UiTransitionDescriptionCollection uiTransitionDescriptionCollection, RectTransform parent, string prefabPath) :
            base(uiTransitionDescriptionCollection, prefabPath, parent)
        {
        }

        public override void Show()
        {
            base.Show();
            CreateUiMap();

            _settingsButton = GetElementComponent<Button>(SettingsButton);
            _closeButton = GetElementComponent<Button>(CloseButton);
            
            _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
            _closeButton.onClick.AddListener(OnCloseButtonClicked);
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            Debug.LogError("HIDE MAIN UI");
            _settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
            _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
            gameObject.SetActive(false);

            base.Hide();
        }

        private void OnCloseButtonClicked()
        {
            onSetTransition?.Invoke(WindowType.CloseWindow.ToString());
        }

        private void OnSettingsButtonClicked()
        {
            onSetTransition?.Invoke(WindowType.SettingsWindow.ToString());
        }
    }
}
