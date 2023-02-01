using Zenject;


namespace Services
{
    public class MenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<string>().AsSingle().NonLazy();
        }
    }
}
