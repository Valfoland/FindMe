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
            _characterData.CharacterCameraObject.transform.position = _characterData.CharacterObject.transform.position;
        }
    }
}
