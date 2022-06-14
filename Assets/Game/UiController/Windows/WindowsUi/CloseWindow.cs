using Game.BusinessLogic.Descriptions;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UiController.Windows.WindowsUi
{
    public class CloseWindow : WindowBase
    {
        private const string CloseButton = "_CloseButton";

        private Button _closeButton;

        public CloseWindow(UiTransitionDescriptionCollection uiTransitionDescriptionCollection, RectTransform parent,
            string prefabPath) : base(uiTransitionDescriptionCollection, prefabPath, parent)
        {
        }

        public override void Show()
        {
            base.Show();
            CreateUiMap();
            
            _closeButton = GetElementComponent<Button>(CloseButton);
            _closeButton.onClick.AddListener(OnCloseButtonClicked);
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
            gameObject.SetActive(false);
            
            base.Hide();
        }
        
        private void OnCloseButtonClicked()
        {
            onSetTransition?.Invoke(WindowType.MainUi.ToString());
        }
    }
}
