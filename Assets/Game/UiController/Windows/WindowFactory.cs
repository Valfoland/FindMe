using System;
using Game.UiController.Transitions;
using Game.UiController.Windows.WindowsUi;

namespace Game.UiController.Windows
{
    public class WindowFactory
    {
        public WindowBase GetWindow(UiStateTransition transition)
        {
            return transition.WindowType switch
            {
                WindowType.MainUi => new MainUi(transition, null, ""),
                WindowType.SettingsWindow => new SettingsWindow(transition, null,""),
                WindowType.CloseWindow => new CloseWindow(transition, null,""),
                _ => throw new Exception("Не найдено окна с именем: " + nameof(transition.WindowType))
            };
        }
    }
}
