using System;
using Game.BusinessLogic.Descriptions;
using Game.Data.BusinessLogic.Descriptions.UiMapDescription;
using Game.UiController.Transitions;
using Game.UiController.Utils;
using Game.UiController.Windows.WindowsUi;
using UnityEngine;

namespace Game.UiController.Windows
{
    public static class WindowFactory
    {
        public static WindowBase GetWindow(WindowType stateType, UiTransitionDescriptionCollection transitionsData)
        {
            var uiCanvasRect = CanvasData.GetUiCanvasElement<RectTransform>();
            
            return stateType switch
            {
                WindowType.MainUi => new MainUi(transitionsData, uiCanvasRect, WindowPrefabPath.MainUi),
                WindowType.SettingsWindow => new SettingsWindow(transitionsData, uiCanvasRect,WindowPrefabPath.SettingsWindow),
                WindowType.CloseWindow => new CloseWindow(transitionsData, uiCanvasRect,WindowPrefabPath.CloseWindow),
                _ => throw new Exception("Не найдено окна с именем: " + nameof(stateType))
            };
        }

        public static UiStateTransition GetWindowTransition(TransitionType transitionType, UiTransitionDescription transitionDescription)
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
