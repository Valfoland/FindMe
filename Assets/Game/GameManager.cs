using Game.BusinessLogic.Context;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameContext context;

        private void Awake()
        {
            context = new GameContext();
        }
    }
}
