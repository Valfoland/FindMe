using UnityEngine;

namespace Game.Creatures.Character
{
    public class CharacterTransform : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
    
        private void Start()
        {
                
        }

        private void Update()
        {
#if UNITY_EDITOR
            
            Debug.LogError(Input.GetAxis("Vertical") + " " + Input.GetAxis("Horizontal"));
            _animator.SetFloat("BlendMove", Input.GetAxis("Vertical"));
#endif
        }
    }
}
