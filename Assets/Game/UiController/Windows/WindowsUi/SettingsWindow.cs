using UnityEngine;

namespace Game.UiController.Windows.WindowsUi
{
    public class SettingsWindow : WindowBase
    {
        public SettingsWindow(RectTransform parent, string prefabPath) : base(parent, prefabPath)
        {
        }

        public override void Show()
        {
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
