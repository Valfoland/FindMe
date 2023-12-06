using FlowBuilders;
using Services;
using Ui;
using UnityEngine.SceneManagement;
using Zenject;

namespace Initial
{
    public class MenuInstaller : MonoInstaller
    {
        private MenuFlowBuilder _menuFlowBuilder;

        public override void Start()
        {
            Container.Resolve<SceneService>().InitializeScene(SceneManager.GetActiveScene().name);
            InstallMenuFlow();
        }

        private void OnDestroy()
        {
            Drop();
        }

        public override void InstallBindings()
        {
            Container.Bind<UiManager>().AsSingle().NonLazy();
        }

        private void InstallMenuFlow()
        {
            _menuFlowBuilder = new MenuFlowBuilder(Container.Resolve<UiManager>());
            _menuFlowBuilder.Build();
        }

        private void Drop()
        {
            _menuFlowBuilder.Drop();
        }
    }
}