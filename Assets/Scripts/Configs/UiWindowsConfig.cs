using Ui;
using UnityEngine;
using Utils;


namespace Configs
{
    [CreateAssetMenu(fileName = "UiWindowsConfig", menuName = "Configs/UiWindowsConfig")]
    public class UiWindowsConfig : ScriptableObject
    {
        [field: SerializeField] public SerializableDictionary<WindowType, GameObject> Windows { get; private set; }
    }
}