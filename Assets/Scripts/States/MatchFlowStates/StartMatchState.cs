using Frameworks.FSM;
using Helpers;

namespace States.MatchFlowStates
{
    public class StartMatchState : StateBase
    {
        public override string Id => "StartMatchState";

        public override void OnEnter()
        {
            StatesSwitchingHelper.SwitchTo(StatesSwitchingHelper.MatchSceneName);

            base.OnEnter();
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}