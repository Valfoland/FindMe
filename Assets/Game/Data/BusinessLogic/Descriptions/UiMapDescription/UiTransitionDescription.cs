using System;
using Frameworks.BlFramework.Base;
using Frameworks.BlFramework.Utils;
using Frameworks.StateMachine;
using Game.UiController.Transitions;
using Game.UiController.Windows;

namespace Game.BusinessLogic.Descriptions
{
    public class UiTransitionDescription : DescriptionBase, IStateTransitionData
    {
        private const string TransitionTypeKey = "TransitionType";

        public TransitionType TransitionType { get; }
        public WindowType DestinationWindow { get; }
        
        public UiTransitionDescription(TreeData nodeData) : base(nodeData)
        {
            if (Enum.TryParse(nodeData.GetString(TransitionTypeKey), out TransitionType transitionType))
            {
                TransitionType = transitionType;
            }
            
            if (Enum.TryParse(nodeData.GetKey(), out WindowType destinationWindow))
            {
                DestinationWindow = destinationWindow;
            }
        }

        public string GetToStateKey()
        {
            return DestinationWindow.ToString();
        }
    }
}
