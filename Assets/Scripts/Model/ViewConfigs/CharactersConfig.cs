using UnityEngine;
using Utils;

namespace BusinessLogic.ViewConfigs
{
    [CreateAssetMenu(fileName = "CharactersConfig", menuName = "Configs/CharactersConfig")]
    public class CharactersConfig : ScriptableObject
    {
        [field: SerializeField] public SerializableDictionary<string, GameObject> CharacterPrefabs { get; private set; } 
    }
}
