using System;
using Frameworks.OEPFramework.UnityEngine.Behaviour;
using Frameworks.StateMachine;
using UnityEngine;

namespace Game.UiController.Windows.WindowsUi
{
    public abstract class WindowBase : GUIBehaviour, IStateAction
    {
        public event Action<IStateTransitionDecision> onSetTransition;
        
        public abstract void Show();
        public abstract void Hide();
        protected abstract void AddTransitionDecisions();
        protected abstract void RemoveTransitionDecisions();
        
        protected readonly StateContext context;

        protected WindowBase(StateContext context, GameObject go) : base(go)
        {
            this.context = context;
        }

        protected WindowBase(StateContext context, string prefabPath, RectTransform parent) : base(prefabPath, parent)
        {
            this.context = context;
        }

        protected WindowBase(StateContext context, GameObject template, RectTransform parent) : base(template, parent)
        {
            this.context = context;
        }
    }
}
