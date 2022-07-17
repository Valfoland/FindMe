using UnityEngine;

namespace Game.Creatures.Character
{
    public class CharacterData : MonoBehaviour
    {
        [field: SerializeField]
        public Animator Animator { get; set; }
        public GameObject CharacterCameraObject { get; set; }
        public GameObject CharacterObject => gameObject;
    }
}
