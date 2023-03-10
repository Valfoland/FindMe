using StateBuilders;
using System;
using Ui;
using Zenject;


namespace Initial
{
    public class MenuInstaller : MonoInstaller
    {
        private MenuStateBuilder _menuUiStateBuilder;
        
        private void Start()
        {
            InstallMenuUi();
        }


        private void OnDestroy()
        {
            Drop();
        }


        public override void InstallBindings()
        {
            Container.Bind<UiManager>().AsSingle().NonLazy();
        }


        private void InstallMenuUi()
        {
            _menuUiStateBuilder = new MenuStateBuilder(Container.Resolve<UiManager>());
            _menuUiStateBuilder.Build();
        }


        private void Drop()
        {
            _menuUiStateBuilder.Drop();
        }
    }
}
