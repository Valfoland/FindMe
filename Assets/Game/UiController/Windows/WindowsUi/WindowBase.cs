using System;
using System.Collections.Generic;
using Frameworks.OEPFramework.UnityEngine.Behaviour;
using Frameworks.StateMachine;
using Game.BusinessLogic.Descriptions;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.UiController.Windows.WindowsUi
{
    public abstract class WindowBase : ControlLoopBehaviour, IStateAction
    {
        protected readonly UiTransitionDescriptionCollection uiTransitionDescriptionCollection;

        protected Action<string> onSetTransition;
        protected GameObject gameObject;
        protected RectTransform rectTransform;

        private readonly RectTransform _parent;

        private Dictionary<string, GameObject> _uiMap;
        private string _prefabPath;
        
        protected WindowBase(UiTransitionDescriptionCollection uiTransitionDescriptionCollection, string prefabPath,
            RectTransform parent)
        {
            this.uiTransitionDescriptionCollection = uiTransitionDescriptionCollection;

            _parent = parent;
            _prefabPath = prefabPath;
        }

        public void SetTransitionAction(Action<string> onSetTransition)
        {
            this.onSetTransition = onSetTransition;
        }

        public virtual void Show()
        {
            if (initialized || dropped) return;
            
            gameObject = Object.Instantiate(Resources.Load<GameObject>(_prefabPath), _parent, false);
            rectTransform = (RectTransform) gameObject.transform;
            Initialize();
        }
        

        public virtual void Hide()
        {
            onSetTransition = null;
            
            base.Drop();
        }

        protected GameObject GetElement(string key)
        {
            return _uiMap[key];
        }

        protected T GetElementComponent<T>(string key) where T : Component
        {
            return _uiMap[key].GetComponent<T>();
        }
        
        public bool TryGetElement(string elementName, out GameObject element)
        {
            return _uiMap.TryGetValue(elementName, out element);
        }
        
        public bool TryGetElementComponent<T>(string elementName, out T component) where T : Component
        {
            if (_uiMap.TryGetValue(elementName, out var element))
            {
                component = element.GetComponent<T>();
                return true;
            }
            
            component = null;
            return false;
        }

        protected bool HasElement(string key)
        {
            return _uiMap.ContainsKey(key);
        }

        protected void CreateUiMap(string prefix = "_")
        {
            _uiMap = new Dictionary<string, GameObject>();
            CreateUiMap(gameObject, prefix);
        }

        private void CreateUiMap(GameObject go, string prefix)
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform child = go.transform.GetChild(i);

                if (child.name.StartsWith(prefix))
                    _uiMap.Add(child.name, child.gameObject);

                if (child.childCount > 0)
                    CreateUiMap(child.gameObject, prefix);
            }
        }
        
        protected override void OnUninitialize()
        {
            Object.Destroy(gameObject);
                
            base.OnUninitialize();
        }
    }
}
