using System;

namespace Frameworks.StateMachine
{
    public interface IStateAction
    {
        void Show(Action<IStateTransition> onSetTransition);
        void Hide();
    }
}
