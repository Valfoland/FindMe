using System;
using Game.BusinessLogic.Descriptions;
using Game.UiController.Windows.WindowsUi;

namespace Game.UiController.Windows
{
    public class WindowFactory
    {
        public WindowBase GetWindow(UiTransitionDescription mainTransitionData, UiTransitionDescriptionCollection transitionsData)
        {
            return mainTransitionData.DestinationWindow switch
            {
                WindowType.MainUi => new MainUi(mainTransitionData, transitionsData, null, ""),
                WindowType.SettingsWindow => new SettingsWindow(mainTransitionData, transitionsData, null,""),
                WindowType.CloseWindow => new CloseWindow(mainTransitionData, transitionsData,null,""),
                _ => throw new Exception("Не найдено окна с именем: " + nameof(mainTransitionData.DestinationWindow))
            };
        }
    }
}
