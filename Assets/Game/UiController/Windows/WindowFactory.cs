using System;
using Game.UiController.Windows.WindowsUi;

namespace Game.UiController.Windows
{
    public class WindowFactory
    {
        public WindowBase GetWindow(WindowType windowType)
        {
            return windowType switch
            {
                WindowType.MainUi => new MainUi(null, ""),
                WindowType.SettingsWindow => new SettingsWindow(null, ""),
                WindowType.CloseWindow => new CloseWindow(null, ""),
                _ => throw new Exception("Не найдено окна с именем: " + nameof(windowType))
            };
        }
    }
}
