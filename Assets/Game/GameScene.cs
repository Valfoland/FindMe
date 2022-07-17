using Frameworks.StateMachine;
using Game.Creatures.Character;
using UnityEngine;

namespace Game
{
    public class GameScene : MonoBehaviour
    {
        private StateController _uiStateController;
        private CharacterCreator _characterCreator;

        private void Awake()
        {
            Initialize();
        }

        private void OnDestroy()
        {
            _characterCreator.Drop();
        }

        private void Initialize()
        {
            _characterCreator = new CharacterCreator();
            _characterCreator.Create();
        }
    }
}
