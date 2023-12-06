using UnityEngine;

namespace Services.Scene
{
    public abstract class BaseSceneData : MonoBehaviour
    {
        protected const string UiRootKey = "UiRoot";

        [SerializeField] protected Canvas uiCanvasPrefab;
        [SerializeField] private string _sceneKey;
        [SerializeField] private Camera _mainCameraPrefab;

        private Camera _mainCamera;
        private Canvas _uiCanvas;
        private RectTransform _uiRoot;

        public string SceneKey => _sceneKey;

        public Camera MainCamera
        {
            get { return _mainCamera; }
            protected set { _mainCamera = value; }
        }
            
        public Canvas Uicanvas
        {
            get { return _uiCanvas; }
            protected set { _uiCanvas = value; }
        }

        public RectTransform UiRoot
        {
            get { return _uiRoot; }
            protected set { _uiRoot = value; }
        }

        public virtual void InitializeSceneData()
        {
            _mainCamera = Instantiate(_mainCameraPrefab);
            _uiCanvas = Instantiate(uiCanvasPrefab);
            _uiRoot = (RectTransform)_uiCanvas.transform.Find(UiRootKey);
        }
    }
}