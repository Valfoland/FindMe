using System;
using Frameworks.BlFramework.Base;
using Frameworks.BlFramework.Utils;
using Frameworks.StateMachine;
using Game.UiController.Transitions;
using Game.UiController.Windows;

namespace Game.Data.BusinessLogic.Descriptions.UiMapDescription
{
    public class UiTransitionDescription : DescriptionBase, IStateTransitionData
    {
        private const string TransitionTypeKey = "TransitionType";

        public TransitionType TransitionType { get; }

        public UiTransitionDescription(TreeData nodeData) : base(nodeData)
        {
            if (Enum.TryParse(nodeData.GetString(TransitionTypeKey), out TransitionType transitionType))
            {
                TransitionType = transitionType;
            }
        }
    }
}
