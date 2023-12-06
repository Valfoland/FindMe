using BusinessLogic.ViewConfigs;
using UnityEngine;

namespace Services
{
    public class ConfigsProvider : MonoBehaviour
    {
        [field: SerializeField] public UiConfig UiConfig { get; private set; }
        [field: SerializeField] public CharactersConfig CharactersConfig { get; private set; }
    }
}