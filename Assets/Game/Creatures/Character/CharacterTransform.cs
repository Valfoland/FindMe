using Frameworks.OEPFramework.UnityEngine.Behaviour;
using UnityEngine;

namespace Game.Creatures.Character
{
    public class CharacterTransform : ICharacterCommand
    {
        private CharacterData _characterData;
        
        public CharacterTransform(CharacterData characterData)
        {
            _characterData = characterData;
        }

        public void DoAction()
        {
#if UNITY_EDITOR
            _characterData.Animator.SetFloat("BlendKoeff", Input.GetAxis("Vertical"));
#endif
        }
    }
}
