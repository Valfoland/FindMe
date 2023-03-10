using Frameworks.FSM;
using Ui;


namespace States
{
    public class MenuState : StateBase
    {
        private readonly MenuStateSettings _menuStateSettings;


        public MenuState(MenuStateSettings menuStateSettings)
        {
            _menuStateSettings = menuStateSettings;
        }


        public override void OnEnter()
        {
            base.OnEnter();

            _menuStateSettings.uiManager.Show<MenuUiScreen>();
        }
    }
}
