using BusinessLogic;
using BusinessLogic.ContextFactory;
using Services;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Initial
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private LoopsInitializer _loopsInitializer;
        [FormerlySerializedAs("_unityConfigsProvider")] [SerializeField] private ConfigsProvider configsProvider;
        [SerializeField] private SceneService _sceneService;
        private PlayerContext _playerContext;
        private SaveStateManager _saveStateManager;

        public override void InstallBindings()
        {
            _loopsInitializer.Initialize();
            InstallPlayer();

            Container.Bind<SceneService>().FromInstance(_sceneService).AsSingle();
            Container.Bind<ConfigsProvider>().FromInstance(configsProvider).AsSingle();
        }

        private void InstallPlayer()
        {
            var contextFactory = new PlayerContextCreator();
            _playerContext = contextFactory.CreateContext(DataProvider.LoadProgress(), DataProvider.LoadRepositories());
            _saveStateManager = new SaveStateManager(_playerContext);
            _saveStateManager.Initialize();

            var playerContextBind = Container.Bind<PlayerContext>().FromInstance(_playerContext);
            playerContextBind.OnInstantiated((_, playerContext) => { ((PlayerContext)playerContext).Initialize(); });
            playerContextBind.AsSingle().NonLazy();
        }

        private void OnDestroy()
        {
            _playerContext.Drop();
            _saveStateManager.Drop();
        }
    }
}