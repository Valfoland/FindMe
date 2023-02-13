using BusinessLogic;
using BusinessLogic.ContextFactory;
using Zenject;


namespace Services
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallPlayer();
        }

        private void InstallPlayer()
        {
            var contextFactory = new DefaultPlayerContextCreator();
            var context = contextFactory.CreateContext(DataKeeper.LoadProgress(), DataKeeper.LoadRepositories());

            var binder = Container.Bind<PlayerContext>().FromInstance(context);
            binder.AsSingle().NonLazy();
            binder.OnInstantiated<PlayerContext>((ctx, obj) =>
            {
                obj.Initialize();
            });
        }
    }
}
