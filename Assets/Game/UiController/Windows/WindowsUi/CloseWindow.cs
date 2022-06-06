using System;
using Frameworks.StateMachine;
using UnityEngine;

namespace Game.UiController.Windows.WindowsUi
{
    public class CloseWindow : WindowBase
    {
        public CloseWindow(IStateTransition transition, RectTransform parent, string prefabPath) : base(transition, prefabPath, parent)
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
           
        }

        protected override void RemoveTransitionDecisions()
        {
            throw new System.NotImplementedException();
        }
    }
}
