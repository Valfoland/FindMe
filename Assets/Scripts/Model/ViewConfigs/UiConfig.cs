using Ui;
using UnityEngine;
using Utils;

namespace BusinessLogic.ViewConfigs
{
    [CreateAssetMenu(fileName = "UiConfig", menuName = "Configs/UiConfig")]
    public class UiConfig : ScriptableObject
    {
        [SerializeField] private SerializableDictionary<WindowType, GameObject> _uiAssets;

        public GameObject GetWindow(WindowType windowType)
        {
            return _uiAssets[windowType];
        }
    }
}
