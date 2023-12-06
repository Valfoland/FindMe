using Basement.OEPFramework.UnityEngine._Base;
using Frameworks.FSM;
using MenuFlowStates;
using States.MatchFlowStates;
using Ui;

namespace FlowBuilders
{
    public class MenuFlowBuilder : DroppableItemBase
    {
        private readonly UiManager _uiManager;
        private readonly FsmController _fsmController;

        public MenuFlowBuilder(UiManager uiManager)
        {
            _uiManager = uiManager;
            _fsmController = new FsmController();
        }
        
        public void Build()
        {
            var menuState = new MenuState(_uiManager);
            var startMatchState = new StartMatchState();
            menuState.AddTransition(startMatchState);

            _fsmController.AddState(menuState);
            _fsmController.AddState(startMatchState);
            _fsmController.Start();
        }

        public override void Drop()
        {
            _fsmController?.Drop();
            
            base.Drop();
        }
    }
}
