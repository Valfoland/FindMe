using UnityEngine;

namespace Creatures.Character
{
    public class CharacterData : MonoBehaviour
    {
        [field: SerializeField] public Animator Animator { get; set; }
        [field: SerializeField] public GameObject CharacterCameraObject { get; set; }
        public GameObject CharacterObject => gameObject;
    }
}