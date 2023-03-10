using Basement.OEPFramework.UnityEngine._Base;
using Frameworks.FSM;
using States;
using Ui;


namespace StateBuilders
{
    public class MenuStateBuilder : DroppableItemBase
    {
        private readonly UiManager _uiManager;
        private readonly FsmController _fsmController;


        public MenuStateBuilder(UiManager uiManager)
        {
            _uiManager = uiManager;
            _fsmController = new FsmController();
        }
        
        public void Build()
        {
            var menuStateSettings = new MenuStateSettings(_uiManager);
            var menuState = new MenuState(menuStateSettings);
            
            _fsmController.AddState(menuState);
            _fsmController.Start();
        }


        public override void Drop()
        {
            _fsmController?.Drop();
            
            base.Drop();
        }
    }
}
