using BusinessLogic;
using BusinessLogic.ContextFactory;
using Services;
using UnityEngine;
using Zenject;


namespace Initial
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private ConfigService _configService;


        public override void InstallBindings()
        {
            InstallPlayer();

            Container.Bind<ConfigService>().FromComponentInNewPrefab(_configService).AsSingle();
        }


        private void InstallPlayer()
        {
            var contextFactory = new DefaultPlayerContextCreator();
            var context = contextFactory.CreateContext(DataKeeper.LoadProgress(), DataKeeper.LoadRepositories());

            var playerContextBind = Container.Bind<PlayerContext>().FromInstance(context);
            playerContextBind.OnInstantiated((_, playerContext) =>
            {
                ((PlayerContext) playerContext).Initialize();
            });
            playerContextBind.AsSingle().NonLazy();
        }
    }
}