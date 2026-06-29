using PoolSystems.Scripts;
using Zenject;

namespace GameInstaller.Scripts.Manager
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            /*Container.Bind<AudioManager>().AsSingle();
            Container.Bind<PlayerController>().AsSingle();*/

            Container.Bind<PoolManager>().FromComponentInHierarchy().AsSingle();
        }
    }
}