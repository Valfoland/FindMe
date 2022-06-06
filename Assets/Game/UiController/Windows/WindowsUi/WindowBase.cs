using System;
using Frameworks.OEPFramework.UnityEngine.Behaviour;
using Frameworks.StateMachine;
using UnityEngine;

namespace Game.UiController.Windows.WindowsUi
{
    public abstract class WindowBase : GUIBehaviour, IStateAction
    {
        protected abstract void AddTransitionDecisions();
        protected abstract void RemoveTransitionDecisions();
        
        protected readonly IStateTransition transition;

        protected WindowBase(IStateTransition transition, GameObject go) : base(go)
        {
            this.transition = transition;
        }

        protected WindowBase(IStateTransition transition, string prefabPath, RectTransform parent) : base(prefabPath, parent)
        {
            this.transition = transition;
        }

        protected WindowBase(IStateTransition transition, GameObject template, RectTransform parent) : base(template, parent)
        {
            this.transition = transition;
        }

        public virtual void Show(Action<IStateTransition> onSetTransition)
        {
            AddTransitionDecisions();
        }
        

        public virtual void Hide()
        {
            RemoveTransitionDecisions();
        }
    }
}
