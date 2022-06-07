using System;
using Game.BusinessLogic.Descriptions;
using Game.UiController.Transitions;
using Game.UiController.Windows.WindowsUi;

namespace Game.UiController.Windows
{
    public class WindowFactory
    {
        public WindowBase GetWindow(WindowType stateType, UiTransitionDescriptionCollection transitionsData)
        {
            return stateType switch
            {
                WindowType.MainUi => new MainUi(transitionsData, null, ""),
                WindowType.SettingsWindow => new SettingsWindow(transitionsData, null,""),
                WindowType.CloseWindow => new CloseWindow(transitionsData,null,""),
                _ => throw new Exception("Не найдено окна с именем: " + nameof(stateType))
            };
        }

        public UiStateTransition GetWindowTransition(TransitionType transitionType, UiTransitionDescription transitionDescription)
        {
            return transitionType switch
            {
                TransitionType.Hard => new HardUiStateTransition(transitionDescription),
                TransitionType.Soft => new SoftUiStateTransition(transitionDescription),
                _ => throw new Exception("Не найдено окна с именем: " + nameof(transitionType))
            };
        }
    }
}
