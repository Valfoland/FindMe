using FlowBuilders;
using Game.Creatures.Character;
using Services;
using Ui;
using UnityEngine.SceneManagement;
using Zenject;

namespace Initial
{
    public class GameInstaller : MonoInstaller
    {
        private MatchFlowBuilder _matchFlowBuilder;

        public override void Start()
        {
            var sceneService = Container.Resolve<SceneService>();
            sceneService.InitializeScene(SceneManager.GetActiveScene().name);
            InstallMatchFlow();
            InstallCharacters(sceneService);
        }
        
        public override void InstallBindings()
        {
            Container.Bind<UiManager>().AsSingle().NonLazy();
        }

        private void InstallCharacters(SceneService sceneService)
        {
            var characterCreator = new CharacterCreator(sceneService, Container.Resolve<ConfigsProvider>());
            characterCreator.Create();
        }

        private void InstallMatchFlow()
        {
            _matchFlowBuilder = new MatchFlowBuilder();
            _matchFlowBuilder.Build();
        }

        private void Drop()
        {
            _matchFlowBuilder.Drop();
        }
    }
}
