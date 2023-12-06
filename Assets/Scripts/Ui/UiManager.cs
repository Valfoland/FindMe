using Services;
using System.Collections.Generic;
using BusinessLogic.ViewConfigs;


namespace Ui
{
    public class UiManager
    {
        private readonly SceneService _sceneService;
        private readonly UiConfig _uiConfig;
        private readonly Dictionary<WindowType, WindowGuiBehaviour> _cachedWindows = new();


        public UiManager(ConfigsProvider configsProvider, SceneService sceneService)
        {
            _sceneService = sceneService;
            _uiConfig = configsProvider.UiConfig;
        }


        private void ShowScreen(WindowGuiBehaviour screen)
        {
            screen.Create();
            screen.Show();
        }


        private void HideScreen(WindowGuiBehaviour screen, bool hideWithDrop)
        {
            screen.Hide(hideWithDrop);
        }


        public T Get<T>(WindowType windowType) where T : WindowGuiBehaviour
        {
            _cachedWindows.TryGetValue(windowType, out var window);
            window ??= UiFactory.GetWindow(windowType, _uiConfig, _sceneService.GetActiveSceneData().UiRoot);

            return (T) window;
        }


        public T Hide<T>(WindowType windowType, bool hideWithDrop = false) where T : WindowGuiBehaviour
        {
            var window = Get<T>(windowType);

            HideScreen(window, hideWithDrop);

            if (hideWithDrop)
            {
                _cachedWindows.Remove(windowType);
            }

            return window;
        }


        public T Hide<T>(T window, bool hideWithDrop = false) where T : WindowGuiBehaviour
        {
            HideScreen(window, hideWithDrop);

            if (hideWithDrop)
            {
                _cachedWindows.Remove(window.WindowType);
            }

            return window;
        }


        public T Show<T>(WindowType windowType) where T : WindowGuiBehaviour
        {
            var window = Get<T>(windowType);

            _cachedWindows.Add(windowType, window);

            ShowScreen(window);

            return window;
        }
    }
}