using Basement.OEPFramework.UnityEngine._Base;
using UnityEngine;


namespace Game.Creatures.Character
{
    public class CharacterCreator : DroppableItemBase
    {
        private const string CharactersPlacement = "Creatures";
        private const string CharacterCameraKey = "CharacterCamera";
        private const string CharacterKey = "Character";

        private Transform _characterPlacement;
        private CharacterController _characterController;

        public CharacterCreator()
        {
            _characterPlacement = GameObject.Find(CharactersPlacement).transform;
        }

        public override void Drop()
        {
            _characterController?.Drop();
            
            base.Drop();
        }

        public void Create()
        {
            //var characterCollection = GameServices.context.GetChild<CharacterPrefabsDescriptionCollection>(DataUtil.Entities.CharacterPrefabs);

            //var cameraResource = Resources.Load<GameObject>(characterCollection.GetChild(CharacterCameraKey).Path);
            //var cameraObject = Object.Instantiate(cameraResource, _characterPlacement);

            //var characterResource = Resources.Load<GameObject>(characterCollection.GetChild(CharacterKey).Path);
            //var characterObject = Object.Instantiate(characterResource, _characterPlacement);

            //var characterData = characterObject.GetComponent<CharacterData>();
            //characterData.CharacterCameraObject = cameraObject;
            
            //_characterController = new CharacterController(characterData);
        }
    }
}
