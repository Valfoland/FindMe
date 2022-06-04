using Game.BusinessLogic;
using Game.BusinessLogic.Context;
using Game.UiManager;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameContext context;

        private UiMap _uiMap;

        private void Awake()
        {
            context = new GameContext();

            _uiMap = new UiMap();
        }
    }
}
