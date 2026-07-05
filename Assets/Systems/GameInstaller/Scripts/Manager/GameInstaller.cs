using Assets.Systems.PlayerControllerSystem.Scripts.Entities;
using Assets.Systems.PoolSystems.Scripts;
using EndlessRoadSystem.Scripts.Core.Interfaces;
using EnemySystem.Scripts.Core.Interfaces;
using EnemySystem.Scripts.Data.Config;
using EnemySystem.Scripts.Data.RunTime;
using PlayerControllerSystem.Scripts.Data.Config;
using PlayerControllerSystem.Scripts.Entities;
using PoolSystems.Scripts;
using PoolSystems.Scripts.Data.Config;
using ShootingSystem.Scripts.Core;
using UnityEngine;
using WeaponSystem.Scripts.Data.Config;
using Zenject;

namespace GameInstaller.Scripts.Manager
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private CD_Player _playerConfigData;
        [SerializeField] private RD_Player _playerRunTimeData;
        [SerializeField] private CD_Pool _poolData;

        #region EnemySystem
        [SerializeField] private CD_Enemy _enemyData;
        [SerializeField] private RD_Enemy _enemyRunTimeData;
        #endregion

        #region ShootingSystem
        [SerializeField] private CD_Bullets _bulletData;
        #endregion

        #region RoadSystem
        [SerializeField] private CD_Road _roadData;
        #endregion


        public override void InstallBindings()
        {
            Container.Bind<IPoolManager>()
                .To<PoolManager>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<IPlayerConfig>()
                .FromInstance((IPlayerConfig)_playerConfigData)
                .AsSingle();
           
            Container.Bind<IPoolConfig>()
                .FromInstance((IPoolConfig)_poolData)
                .AsSingle();

            Container.Bind<IEnemyConfig>()
                .FromInstance((IEnemyConfig)_enemyData)
                .AsSingle();

            Container.Bind<IEnemyRuntime>()
                .FromInstance((IEnemyRuntime)_enemyRunTimeData)
                .AsSingle();

            Container.Bind<IBulletsData>()
                .FromInstance((IBulletsData)_bulletData)
                .AsSingle();

            Container.Bind<IRoadConfig>()
                .FromInstance((IRoadConfig)_roadData)
                .AsSingle();

            Container.Bind<IPlayerRunTime>()
                .FromInstance((IPlayerRunTime)_playerRunTimeData)
                .AsSingle();
        }
    }
}