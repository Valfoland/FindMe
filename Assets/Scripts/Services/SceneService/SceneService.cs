using System.Linq;
using Services.Scene;
using UnityEngine;

namespace Services
{
    public class SceneService : MonoBehaviour
    {
        [SerializeField] private BaseSceneData[] _sceneData;

        private string _currentSceneKey;

        public void InitializeScene(string sceneKey)
        {
            _currentSceneKey = sceneKey;
            _sceneData.First(s => s.SceneKey == sceneKey).InitializeSceneData();
        }

        public BaseSceneData GetActiveSceneData()
        {
            return _sceneData.First(s => s.SceneKey == _currentSceneKey);
        }
    }
}