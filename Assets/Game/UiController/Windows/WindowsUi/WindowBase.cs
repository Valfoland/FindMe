using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.UiController.Windows.WindowsUi
{
    public abstract class WindowBase
    {
        public event Action<string> onSetTransition;
        
        public abstract void Show();
        public abstract void Hide();

        protected RectTransform parent;
        protected RectTransform rectTransform;
        protected GameObject gameObject;
        
        private string _prefabPath;

        protected WindowBase(RectTransform parent, string prefabPath)
        {
            this.parent = parent;
            _prefabPath = prefabPath;
        }

        protected virtual void Create()
        {
            if (!string.IsNullOrEmpty(_prefabPath))
            {
                GetPrefabFromResources();
            }
        }

        private void GetPrefabFromResources()
        {
            var resource = Resources.Load<RectTransform>(_prefabPath);
            rectTransform = Object.Instantiate(resource, parent);
            gameObject = rectTransform.gameObject;
        }
    }
}
