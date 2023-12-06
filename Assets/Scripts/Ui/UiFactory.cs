using BusinessLogic.ViewConfigs;
using Ui.Screens;
using UnityEngine;


namespace Ui
{
    public static class UiFactory 
    {
        public static WindowGuiBehaviour GetWindow(WindowType windowType, UiConfig uiConfig, RectTransform parent)
        {
            var windowPrefab = uiConfig.GetWindow(windowType);
            
            return windowType switch
            {
                WindowType.MenuScreen => new MenuScreen(windowPrefab, parent, WindowType.MenuScreen)
            };

        }
    }
}
