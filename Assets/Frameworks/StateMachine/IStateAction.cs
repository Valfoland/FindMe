using System;

namespace Frameworks.StateMachine
{
    public interface IStateAction
    {
        void SetTransitionAction(Action<string> onSetTransition);
        void Show();
        void Hide();
    }
}
