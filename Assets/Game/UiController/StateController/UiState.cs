using System;
using System.Collections.Generic;
using Frameworks.StateMachine;
using Game.BusinessLogic.Descriptions;
using Game.UiController.Windows;

namespace Game.UiController.StateController
{
    public class UiState : State
    {
        public UiState(Action<IStateTransitionData> onNeedUpdateState, IStateTransitionData mainTransitionData,
            IEnumerable<KeyValuePair<string, IStateTransitionData>> transitionsData) : base(onNeedUpdateState, mainTransitionData, transitionsData)
        {

        }

        protected override IStateAction GetStateAction(IStateTransitionData mainTransitionData, IEnumerable<KeyValuePair<string, IStateTransitionData>> transitionsData)
        {
            return new WindowFactory().GetWindow((UiTransitionDescription) mainTransitionData, (UiTransitionDescriptionCollection) transitionsData);
        }
    }
}
