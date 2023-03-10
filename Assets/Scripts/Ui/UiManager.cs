using Configs;
using Services;
using System;
using System.Collections.Generic;
using Ui.TransitionScreens;


namespace Ui
{
    public class UiManager
    {
        private readonly UiWindowsConfig _windowsConfig;
        private readonly Dictionary<WindowType, WindowGuiBehaviour> _cachedWindows = new();

        private TransitionScreen _transitionScreen;


        public UiManager(ConfigService configService)
        {
            _windowsConfig = configService.WindowsConfig;
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


        public T Get<T>(WindowType uiScreenType) where T : WindowGuiBehaviour
        {
            var screenPrefab = _windowsConfig.Windows[uiScreenType];

            _cachedWindows.TryGetValue(uiScreenType, out var screen);
            screen ??= UiMap.GetScreen(uiScreenType, screenPrefab);

            return (T) screen;
        }


        public T Hide<T>(WindowType uiScreenType, Action onComplete, bool hideWithDrop = false) where T : WindowGuiBehaviour
        {
            var window = Get<T>(uiScreenType);

            HideScreen(window, hideWithDrop);
            //window.StateChanged

            return window;
        }


        public T Show<T>(WindowType uiScreenType, Action onComplete, WindowType transitionWindowType = WindowType.None) where T : WindowGuiBehaviour
        {
            var window = Get<T>(uiScreenType);

            ShowScreen(window);

            if (transitionWindowType != WindowType.None)
            {
                Transit(GetTransitionScreen(transitionWindowType));
            }

            return window;
        }


        public T Show<T>(T screen, WindowType transitionWindowType = WindowType.None) where T : WindowGuiBehaviour
        {
            ShowScreen(screen);

            if (transitionWindowType != WindowType.None)
            {
                Transit(GetTransitionScreen(transitionWindowType));
            }

            return screen;
        }


        private void OnStateChanged()
        {
            
        }


        private TransitionScreen GetTransitionScreen(WindowType transitionScreenType)
        {
            return (TransitionScreen) UiMap.GetScreen(transitionScreenType, _windowsConfig.Windows[transitionScreenType]);
        }


        private void Transit(TransitionScreen transition)
        {
            _transitionScreen?.Drop();
            _transitionScreen = transition;
            transition.Create();
            transition.Transit();
        }
    }
}