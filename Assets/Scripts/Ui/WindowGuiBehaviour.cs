using Basement.OEPFramework.UnityEngine.Behaviour;
using Basement.OEPFramework.UnityEngine.Loop;
using System;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Ui
{
    public class WindowGuiBehaviour : GUIBehaviour
    {
        public event Action<WindowGuiBehaviourState> OnStateChanged;


        public event Action OnWindowShow;


        public event Action OnWindowShown;


        public event Action OnWindowHide;


        public event Action OnWindowHidden;


        protected event Action<bool> OnWindowActivated;


        private bool _dropItem = true;


        public WindowType WindowType { get; }


        public WindowGuiBehaviourState CurrentState { get; private set; } = WindowGuiBehaviourState.None;


        public bool IsTapable => CurrentState == WindowGuiBehaviourState.Visible;

        
        protected WindowGuiBehaviour(GameObject template, RectTransform parent, WindowType windowType) : base(template,
            parent)
        {
            WindowType = windowType;
        }


        public override void Create()
        {
            if (!initialized)
            {
                base.Create();

                CreateElementsMap();

                LoopOn(Loops.UPDATE, Update);
                Play();
            }
        }


        public override void Drop()
        {
            if (dropped)
            {
                return;
            }

            OnWindowShow = null;
            OnWindowShown = null;
            OnWindowHide = null;
            OnWindowHidden = null;

            SetState(WindowGuiBehaviourState.Destroyed);
            base.Drop();
        }


        public void Show()
        {
            OnShow();
            SetState(WindowGuiBehaviourState.Constructed);
            SetActive(true);
        }


        public void Hide(bool dropItem = true)
        {
            OnHide();
            _dropItem = dropItem;

            if (CurrentState == WindowGuiBehaviourState.Constructed || dropped)
            {
                return;
            }

            SetState(WindowGuiBehaviourState.Closing);
        }


        public virtual void ProcessEscape()
        {
            if (!IsTapable)
            {
                return;
            }

            Hide();
        }


        public override void SetActive(bool active)
        {
            if (gameObject != null && gameObject.activeSelf != active)
            {
                OnWindowActivated?.Invoke(active);
            }

            base.SetActive(active);
        }


        protected virtual void OnShow()
        {
            OnWindowShow?.Invoke();
        }


        protected virtual void OnShown()
        {
            OnWindowShown?.Invoke();
        }


        protected virtual void OnHide()
        {
            OnWindowHide?.Invoke();
        }


        protected virtual void OnHidden()
        {
            OnWindowHidden?.Invoke();
        }


        protected virtual void OnUpdate() { }


        protected override void OnUninitialize()
        {
            if (_dropItem)
            {
                Object.Destroy(gameObject);
            }
            else
            {
                SetActive(false);
            }
        }


        protected void SetState(WindowGuiBehaviourState newState)
        {
            if (CurrentState != newState)
            {
                CurrentState = newState;
                OnStateChanged?.Invoke(newState);
            }
        }


        private void WindowIsClosing()
        {
            SetState(WindowGuiBehaviourState.Hidden);
            OnHidden();
            Drop();
        }


        private void WindowIsOpening()
        {
            SetState(WindowGuiBehaviourState.Visible);
            OnShown();
        }


        private void Update()
        {
            if (CurrentState == WindowGuiBehaviourState.Closing)
            {
                WindowIsClosing();
                return;
            }

            if (CurrentState == WindowGuiBehaviourState.Constructed)
            {
                WindowIsOpening();
            }

            if (CurrentState == WindowGuiBehaviourState.Visible)
            {
                OnUpdate();
            }
        }
    }
}