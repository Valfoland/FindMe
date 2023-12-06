using UnityEngine;

namespace Services.Scene
{
    public class MatchSceneData : BaseSceneData
    {
        [SerializeField] private Camera _uiCameraPrefab;
        [SerializeField] private GameObject _environmentRootPrefab;
        [SerializeField] private GameObject _chararctersRootPrefab;
        
        private Camera _uiCamera;
        private GameObject _environmentRoot;
        private GameObject _charactersRoot;

        public Camera UiCamera => _uiCamera;
        public GameObject EnvironmentRoot => _environmentRoot;
        public GameObject CharactersRoot => _charactersRoot;

        public override void InitializeSceneData()
        {
            Uicanvas = Instantiate(uiCanvasPrefab);
            UiRoot = (RectTransform)Uicanvas.transform.Find(UiRootKey);
            _uiCamera = Instantiate(_uiCameraPrefab);
            _environmentRoot = Instantiate(_environmentRootPrefab);
            _charactersRoot = Instantiate(_chararctersRootPrefab);
        }
    }
}