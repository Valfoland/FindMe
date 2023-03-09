using Ui;
using Zenject;


namespace Initial
{
    public class MenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<UiManager>().AsSingle().NonLazy();
        }
    }
}
