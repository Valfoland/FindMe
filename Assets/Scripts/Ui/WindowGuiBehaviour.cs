using Basement.OEPFramework.UnityEngine.Behaviour;
using Basement.OEPFramework.UnityEngine.Loop;
using System;
using System.Collections.Generic;
using System.Linq;
using Ui.GuiEffects;
using UnityEngine;


namespace Ui
{
    public class WindowGuiBehaviour : GUIBehaviour
    {
        private const string SoundClose = "";

        protected readonly IList<GuiEffect> guiEffects = new List<GuiEffect>();
        private bool _dropItem = true;

        public WindowType WindowType { get; private set; }

        public event Action<WindowGuiBehaviourState> StateChanged;

        protected event Action<bool> WindowActivated;

        public WindowGuiBehaviourState CurrentState { get; private set; } = WindowGuiBehaviourState.None;

        public virtual bool IsTapable => CurrentState == WindowGuiBehaviourState.Visible;


        protected WindowGuiBehaviour(GameObject go, WindowType windowType) : base(go)
        {
            WindowType = windowType;
        }


        protected WindowGuiBehaviour(string prefabPath, RectTransform parent, WindowType windowType) : base(prefabPath, parent)
        {
            WindowType = windowType;
        }


        protected WindowGuiBehaviour(GameObject template, RectTransform parent, WindowType windowType) : base(template, parent)
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

            foreach (var effectBehaviour in guiEffects)
            {
                effectBehaviour.Drop();
            }

            guiEffects.Clear();

            SetState(WindowGuiBehaviourState.Destroyed);
            base.Drop();
        }


        public virtual void Show()
        {
            SetState(WindowGuiBehaviourState.Constructed);
            SetActive(true);

            foreach (var effectBehaviour in guiEffects)
            {
                effectBehaviour.Show();
            }
        }


        public virtual void Hide(bool dropItem = true)
        {
            _dropItem = dropItem;

            if (CurrentState == WindowGuiBehaviourState.Constructed || dropped)
            {
                return;
            }

            SetState(WindowGuiBehaviourState.Closing);

            if (guiEffects.Count > 0)
            {
                PlaySound(SoundClose);
            }

            foreach (var effectBehaviour in guiEffects)
            {
                effectBehaviour.Hide();
            }
        }


        public void AddEffectBehaviour(GuiEffect effectBehaviour)
        {
            guiEffects.Add(effectBehaviour);
        }


        public bool RemoveEffectBehaviour(GuiEffect effectBehaviour)
        {
            return guiEffects.Remove(effectBehaviour);
        }


        public bool HasEffectBehaviour<T>() where T : GuiEffect
        {
            return guiEffects.OfType<T>().Any();
        }


        public T GetBehaviour<T>() where T : GuiEffect
        {
            return (T) guiEffects.FirstOrDefault(behaviour => behaviour is T);
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
                WindowActivated?.Invoke(active);
            }

            base.SetActive(active);
        }


        protected virtual void OnUpdate() { }


        protected void SetState(WindowGuiBehaviourState newState)
        {
            if (CurrentState != newState)
            {
                CurrentState = newState;
                StateChanged?.Invoke(newState);
            }
        }


        protected void PlaySound(string soundId)
        {
            if (!string.IsNullOrEmpty(soundId)) { }
        }


        private void WindowIsClosing()
        {
            var check = true;

            foreach (var effectBehaviour in guiEffects)
            {
                if (effectBehaviour.State == GuiEffectState.Hidden)
                {
                    continue;
                }

                check = false;
                break;
            }

            if (check)
            {
                SetState(WindowGuiBehaviourState.Hidden);

                if (_dropItem)
                {
                    Drop();
                }
                else
                {
                    SetActive(false);
                }
            }
        }


        private void WindowIsOpening()
        {
            var check = true;

            foreach (var effectBehaviour in guiEffects)
            {
                if (effectBehaviour.State == GuiEffectState.Showed)
                {
                    continue;
                }

                check = false;
                break;
            }

            if (check)
            {
                SetState(WindowGuiBehaviourState.Visible);
            }
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