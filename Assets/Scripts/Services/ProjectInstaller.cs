using Zenject;


namespace Services
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Container.Bind<IContext>().To<PlayerContext>().AsSingle().NonLazy();
        }
    }
}
