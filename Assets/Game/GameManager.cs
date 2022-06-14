using Frameworks.StateMachine;
using Game.BusinessLogic.Context;
using Game.BusinessLogic.Descriptions;
using Game.BusinessLogic.Utils;
using Game.UiController.StateController;
using Game.UiController.Utils;
using Game.UiController.Windows;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameContext context;

        private StateController _uiStateController;

        private void Awake()
        {
            context = new GameContext();
            StartWindowStateController();
        }

        private void StartWindowStateController()
        {
            _uiStateController = new UiStateController(context.GetChild<UiMapDescriptionCollection>(DataUtil.Entities.UiMap));
            _uiStateController.SwitchState(WindowType.MainUi.ToString());
        }
    }
}
