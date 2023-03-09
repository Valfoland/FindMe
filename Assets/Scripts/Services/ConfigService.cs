using Configs;
using UnityEngine;


namespace Services
{
    public class ConfigService : MonoBehaviour
    {
        [field: SerializeField] public UiWindowsConfig WindowsConfig { get; private set; }
    }
}