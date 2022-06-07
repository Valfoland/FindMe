using System;

namespace Frameworks.StateMachine
{
    public interface IStateAction
    {
        void Show(Action<IStateTransitionData> onSetTransition);
        void Hide();
    }
}
