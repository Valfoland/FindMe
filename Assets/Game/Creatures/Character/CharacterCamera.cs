using UnityEngine;

namespace Game.Creatures.Character
{
    public class CharacterCamera : ICharacterCommand
    {
        private CharacterData _characterData;
        
        public CharacterCamera(CharacterData characterData)
        {
            _characterData = characterData;
        }
    
        public void DoAction()
        {
            var characterPos = _characterData.CharacterObject.transform.position;
            var pos = new Vector3(characterPos.x, characterPos.y + 5, characterPos.z);
            _characterData.CharacterCameraObject.transform.position = pos;
        }
    }
}
