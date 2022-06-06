using System;
using Frameworks.StateMachine;

namespace Game.UiController.StateController
{
    public class UiStateController : Frameworks.StateMachine.StateController
    {
        protected override State GetState(Action<IStateTransition> onSetTransition, IStateTransition transition)
        {
            return new UiState(onSetTransition, transition);
        }
    }
}
