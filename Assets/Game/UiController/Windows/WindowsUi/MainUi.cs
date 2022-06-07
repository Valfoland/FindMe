using System;
using Frameworks.StateMachine;
using Game.BusinessLogic.Descriptions;
using UnityEngine;

namespace Game.UiController.Windows.WindowsUi
{
    public class MainUi : WindowBase
    {
        public MainUi(IStateTransitionData transitionData, UiTransitionDescriptionCollection uiTransitionDescriptionCollection, RectTransform parent, string prefabPath) :
            base(transitionData, uiTransitionDescriptionCollection, prefabPath, parent)
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
