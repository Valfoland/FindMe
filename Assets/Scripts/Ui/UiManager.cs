using Configs;
using Services;
using System;
using System.Collections.Generic;
using Ui.TransitionScreens;
using UnityEngine;


namespace Ui
{
    public class UiManager
    {
        private readonly UiWindowsConfig _windowsConfig;
        private readonly Dictionary<WindowType, DynamicGuiBehaviour> _cachedWindows = new();

        private TransitionScreen _transitionScreen;


        public UiManager(ConfigService configService)
        {
            _windowsConfig = configService.WindowsConfig;
            Debug.LogError("CONF");
        }

        
        private void ShowScreen(DynamicGuiBehaviour screen)
        {
            screen.Create();
            screen.Show();
        }


        private void HideScreen(DynamicGuiBehaviour screen, bool hideWithDrop)
        {
            screen.Hide(hideWithDrop);
        }


        public T Get<T>(WindowType uiScreenType) where T : DynamicGuiBehaviour
        {
            var screenPrefab = _windowsConfig.Windows[uiScreenType];

            _cachedWindows.TryGetValue(uiScreenType, out var screen);
            screen ??= UiMap.GetScreen(uiScreenType, screenPrefab);

            return (T) screen;
        }


        public T Hide<T>(WindowType uiScreenType, Action onComplete, bool hideWithDrop = false) where T : DynamicGuiBehaviour
        {
            var window = Get<T>(uiScreenType);

            HideScreen(window, hideWithDrop);
            //window.StateChanged

            return window;
        }


        public T Show<T>(WindowType uiScreenType, Action onComplete, WindowType transitionWindowType = WindowType.None) where T : DynamicGuiBehaviour
        {
            var window = Get<T>(uiScreenType);

            ShowScreen(window);

            if (transitionWindowType != WindowType.None)
            {
                Transit(GetTransitionScreen(transitionWindowType));
            }

            return window;
        }


        public T Show<T>(T screen, WindowType transitionWindowType = WindowType.None) where T : DynamicGuiBehaviour
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