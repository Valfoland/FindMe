using System;
using Frameworks.OEPFramework.UnityEngine.Behaviour;
using Frameworks.StateMachine;
using Game.BusinessLogic.Descriptions;
using UnityEngine;

namespace Game.UiController.Windows.WindowsUi
{
    public abstract class WindowBase : GUIBehaviour, IStateAction
    {
        protected readonly UiTransitionDescriptionCollection uiTransitionDescriptionCollection;

        protected WindowBase(UiTransitionDescriptionCollection uiTransitionDescriptionCollection, GameObject go) : base(go)
        {
            this.uiTransitionDescriptionCollection = uiTransitionDescriptionCollection;
        }

        protected WindowBase(UiTransitionDescriptionCollection uiTransitionDescriptionCollection, string prefabPath,
            RectTransform parent) : base(prefabPath, parent)
        {
            this.uiTransitionDescriptionCollection = uiTransitionDescriptionCollection;
        }

        protected WindowBase(UiTransitionDescriptionCollection uiTransitionDescriptionCollection, GameObject template, RectTransform parent) : base(template, parent)
        {
            this.uiTransitionDescriptionCollection = uiTransitionDescriptionCollection;
        }

        public virtual void Show(Action<IStateTransitionData> onSetTransition)
        {

        }
        

        public virtual void Hide()
        {

        }
    }
}
