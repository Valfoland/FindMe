using System;

namespace Frameworks.StateMachine
{
    public interface IStateAction
    {
        event Action<IStateTransitionDecision> onSetTransition;
        void Show();
        void Hide();
    }
}
