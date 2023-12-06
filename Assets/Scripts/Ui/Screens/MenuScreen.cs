using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Screens
{
    public class MenuScreen : WindowGuiBehaviour
    {
        private const string StartMatchButtonKey = "_ButtonStartMatch";
        private const string ExitGameButtonKey = "_ButtonExitApp";

        private Button _exitButton;
        private Button _startMatchButton;

        private Action _onExit;
        private Action _onMatchStarted;

        public MenuScreen(GameObject template, RectTransform parent, WindowType windowType) : base(template, parent,
            windowType)
        {
        }

        public void SetupActions(Action onExit, Action onMatchStarted)
        {
            _onExit = onExit;
            _onMatchStarted = onMatchStarted;
        }

        public override void Create()
        {
            base.Create();

            _exitButton = GetElementComponent<Button>(ExitGameButtonKey);
            _startMatchButton = GetElementComponent<Button>(StartMatchButtonKey);
        }

        protected override void OnShow()
        {
            base.OnShow();
            _exitButton.onClick.AddListener(ExitButton_OnClick);
            _startMatchButton.onClick.AddListener(StartMatchButton_OnClick);
        }

        protected override void OnHide()
        {
            _exitButton.onClick.RemoveListener(ExitButton_OnClick);
            _startMatchButton.onClick.RemoveListener(StartMatchButton_OnClick);
            base.OnHide();
        }

        private void ExitButton_OnClick()
        {
            _onExit();
        }

        private void StartMatchButton_OnClick()
        {
            _onMatchStarted();
        }
    }
}