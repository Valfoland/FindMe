using System.Collections.Generic;
using Frameworks.OEPFramework.UnityEngine.Behaviour;
using Frameworks.OEPFramework.UnityEngine.Loop;
using UnityEngine;

namespace Game.Creatures.Character
{
    public class CharacterController : LoopBehaviour
    {
        private GameObject character;
        private GameObject characterCamera;
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
