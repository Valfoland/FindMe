using System;
using Frameworks.StateMachine;
using Game.UiController.Transitions;
using Game.UiController.Windows;

namespace Game.UiController.StateController
{
    public class UiState : State
    {
        public UiState(Action<IStateTransition> onNeedUpdateState, IStateTransition transition) : base(onNeedUpdateState, transition)
        {
            
        }

        protected override IStateAction GetStateAction(IStateTransition transition)
        {
            return new WindowFactory().GetWindow((UiStateTransition) transition);
        }
    }
}
