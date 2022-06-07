using System;
using Frameworks.StateMachine;
using Game.BusinessLogic.Descriptions;
using UnityEngine;

namespace Game.UiController.Windows.WindowsUi
{
    public class CloseWindow : WindowBase
    {
        public CloseWindow(UiTransitionDescriptionCollection uiTransitionDescriptionCollection, RectTransform parent,
            string prefabPath) : base(uiTransitionDescriptionCollection, prefabPath, parent)
        {
        }

        public override void Show(Action<IStateTransitionData> onSetTransition)
        {
            base.Show(onSetTransition);
            
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
            
            base.Hide();
        }
    }
}
