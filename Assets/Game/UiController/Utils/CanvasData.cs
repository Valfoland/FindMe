using UnityEngine;

namespace Game.UiController.Utils
{
    public static class CanvasData
    {
        public const string UiCanvasKey = "UiCanvas";
        
        private static Canvas _uiCanvas;

        public static Canvas GetUiCanvas()
        {
            if (_uiCanvas == null)
            {
                Initialize(UiCanvasKey);
            }

            return _uiCanvas;
        }
        
        public static T GetUiCanvasElement<T>()
        {
            if (_uiCanvas == null)
            {
                Initialize(UiCanvasKey);
            }

            return _uiCanvas.GetComponent<T>();
        }
        
        private static void Initialize(string canvasKey)
        {
            _uiCanvas = GameObject.Find(canvasKey).GetComponent<Canvas>();
        }
    }
}
