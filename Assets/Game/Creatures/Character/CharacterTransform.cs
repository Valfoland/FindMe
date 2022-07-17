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
            
            Debug.LogError(Input.GetAxis("Vertical") + " " + Input.GetAxis("Horizontal"));
            _characterData.Animator.SetFloat("BlendMove", Input.GetAxis("Vertical"));
#endif
        }
    }
}
