using UnityEngine;

namespace Game.UiController.Windows.WindowsUi
{
    public class MainUi : WindowBase
    {
        public MainUi(RectTransform parent, string prefabPath) : base(prefabPath, parent)
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
