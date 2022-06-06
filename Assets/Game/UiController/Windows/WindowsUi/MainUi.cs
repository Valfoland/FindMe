using System;
using Frameworks.StateMachine;
using UnityEngine;

namespace Game.UiController.Windows.WindowsUi
{
    public class MainUi : WindowBase
    {
        public MainUi(IStateTransition transition, RectTransform parent, string prefabPath) : base(transition, prefabPath, parent)
        {
        }

        public override void Show(Action<IStateTransition> onSetTransition)
        {
            base.Show(onSetTransition);
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
            base.Hide();
        }

        protected override void AddTransitionDecisions()
        {
            throw new System.NotImplementedException();
        }

        protected override void RemoveTransitionDecisions()
        {
            throw new System.NotImplementedException();
        }
    }
}
