using Basement.OEPFramework.UnityEngine.Behaviour;
using Basement.OEPFramework.UnityEngine.Loop;
using System.Collections.Generic;


namespace Game.Creatures.Character
{
    public class CharacterController : LoopBehaviour
    {
        private CharacterData _characterData;
        
        private List<ICharacterCommand> _commands = new();
        
        public CharacterController(CharacterData characterData)
        {
            _characterData = characterData;

            RegistryCommands();
            
            LoopOn(Loops.UPDATE, Update);
        }
        
        private void RegistryCommands()
        {
            _commands.Add(new CharacterTransform(_characterData));   
            _commands.Add(new CharacterCamera(_characterData));   
        }

        private void Update()
        {
            foreach (var command in _commands)
            {
                command.DoAction();
            }
        }
    }
}
