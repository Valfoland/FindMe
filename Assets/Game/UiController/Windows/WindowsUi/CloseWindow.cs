using UnityEngine;

namespace Game.UiController.Windows.WindowsUi
{
    public class CloseWindow : WindowBase
    {
        public CloseWindow(RectTransform parent, string prefabPath) : base(prefabPath, parent)
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
