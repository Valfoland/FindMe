namespace Frameworks.StateMachine
{
    public interface IStateTransition
    {
        State From { get; }
        State To { get; }
        void TransitionTo();
    }
}
