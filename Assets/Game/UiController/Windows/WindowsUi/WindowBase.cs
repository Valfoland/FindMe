using System;
using Frameworks.OEPFramework.UnityEngine.Behaviour;
using Frameworks.StateMachine;
using Game.BusinessLogic.Descriptions;
using UnityEngine;

namespace Game.UiController.Windows.WindowsUi
{
    public abstract class WindowBase : GUIBehaviour, IStateAction
    {
        protected readonly IStateTransitionData transitionData;

        protected WindowBase(IStateTransitionData transitionData, GameObject go) : base(go)
        {
            this.transitionData = transitionData;
        }

        protected WindowBase(IStateTransitionData transitionData, UiTransitionDescriptionCollection uiTransitionDescriptionCollection, string prefabPath,
            RectTransform parent) : base(prefabPath, parent)
        {
            this.transitionData = transitionData;
        }

        protected WindowBase(IStateTransitionData transitionData, GameObject template, RectTransform parent) : base(template, parent)
        {
            this.transitionData = transitionData;
        }

        public virtual void Show(Action<IStateTransitionData> onSetTransition)
        {

        }
        

        public virtual void Hide()
        {

        }
    }
}
