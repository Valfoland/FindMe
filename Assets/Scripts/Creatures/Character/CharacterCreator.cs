using Basement.OEPFramework.UnityEngine._Base;
using Creatures.Character;
using Services;
using Services.Scene;
using UnityEngine;
using CharacterController = Creatures.Character.CharacterController;


namespace Game.Creatures.Character
{
    public class CharacterCreator : DroppableItemBase
    {
        private const string CharactersPlacement = "Creatures";

        private readonly ConfigsProvider _configsProvider;
        private readonly Transform _characterPlacement;
        private CharacterController _characterController;

        public CharacterCreator(SceneService sceneService, ConfigsProvider configsProvider)
        {
            _configsProvider = configsProvider;
            _characterPlacement = ((MatchSceneData)sceneService.GetActiveSceneData()).CharactersRoot.transform;
        }

        public override void Drop()
        {
            _characterController?.Drop();

            base.Drop();
        }

        public void Create()
        {
            var characterResource = _configsProvider.CharactersConfig.CharacterPrefabs["Test"];
            var characterObject = Object.Instantiate(characterResource, _characterPlacement);
            var characterData = characterObject.GetComponent<CharacterData>();
            _characterController = new CharacterController(characterData);
        }
    }
}