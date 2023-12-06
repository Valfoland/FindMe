using Frameworks.FSM;
using Ui;
using Ui.Screens;
using UnityEngine;

namespace MenuFlowStates
{
    public class MenuState : StateBase
    {
        public override string Id => "MenuState";
        
        private readonly UiManager _uiManager;
        private MenuScreen _menuScreen;
        
        public MenuState(UiManager uiManager)
        {
            _uiManager = uiManager;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _menuScreen = _uiManager.Show<MenuScreen>(WindowType.MenuScreen);
            _menuScreen.SetupActions(HandleOnExit, HandleOnMatchStarted);
        }

        public override void OnExit()
        {
            _uiManager.Hide(_menuScreen, true);
            
            base.OnExit();
        }

        private void HandleOnExit()
        {
            Application.Quit();
        }

        private void HandleOnMatchStarted()
        {
            FinishState();
        }
    }
}