namespace Frameworks.StateMachine
{
    public interface IStateTransition
    {
        void TransitionTo(State previousState, State nextState);
        T GetTransitionData<T>();
    }
}
