using System;
using System.Collections.Generic;
using Frameworks.StateMachine;
using Game.BusinessLogic.Descriptions;
using Game.UiController.Windows;

namespace Game.UiController.StateController
{
    public class UiState : State
    {
        public UiState(Frameworks.StateMachine.StateController stateController, string stateId,
            IStateTransitionData transitionsData) : base(stateController, stateId, transitionsData)
        {

        }

        protected override IStateAction GetStateAction(string stateId, IStateTransitionData transitionsData)
        {
            if (Enum.TryParse(stateId, out WindowType windowType))
            {
                return WindowFactory.GetWindow(windowType, (UiTransitionDescriptionCollection) transitionsData);
            }

            throw new Exception("Не возможно распарсить Id окна");
        }
    }
}
