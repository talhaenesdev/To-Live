using EnemySystem.Scripts.Core.Interfaces;
using EnemySystem.Scripts.Data.VOs;
using PoolSystems.Scripts;
using ShootingSystem.Scripts.Core;
using UnityEngine;
using WeaponSystem.Scripts.Data.Config;
using Zenject;

namespace EnemySystem.Scripts.Entities
{
    public class EnemyManager : MonoBehaviour
    {
        #region EnemySystem
        [Inject] private IEnemyConfig _enemyData;
        [Inject] private IEnemyRuntime _enemyRunTimeData;
        #endregion

        #region ShootingSystem
        [Inject] private IBulletsData _bulletData;
        #endregion

        #region PoolSystem
        [Inject] private IPoolManager _poolManager;
        #endregion

        #region EnemyMap
        private SerializableDictionary<int,Obstacle> _enemies = new SerializableDictionary<int, Obstacle>();
        #endregion

        private void Start()
        {
            var enemyCount = _enemyData.EnemyData.Count;
            _enemyRunTimeData.EnemyRunTimeData.Clear();

            for (int i = 0; i < enemyCount; i++)
            {
                var enemy = _poolManager.Get<Obstacle>("MainEnemy");

                enemy.SetName(_enemyData.EnemyData[i].Name);
                enemy.SetHealthText(_enemyData.EnemyData[i].StartHealth);
                enemy.SetPosition(_enemyData.EnemyData[i].StartPosition);
                enemy.SetId(i);
                enemy.CreateEnemy();
                enemy.ReturnToPool += ReturnBulletToPool;
                enemy.TakeDamage += TakeDamage;

                EnemyRVO enemyRVO = new EnemyRVO()
                {
                    Health = _enemyData.EnemyData[i].StartHealth,
                };

                _enemyRunTimeData.EnemyRunTimeData.Add(i, enemyRVO);
                _enemies.Add(i, enemy);
            }
        }

        private void TakeDamage(int enemyId, float damage)
        {
            _enemyRunTimeData.EnemyRunTimeData[enemyId].Health -= damage;
            _enemies[enemyId].SetHealthText(_enemyRunTimeData.EnemyRunTimeData[enemyId].Health);
            _enemies[enemyId].DamageModel();

            if (_enemyRunTimeData.EnemyRunTimeData[enemyId].Health <= 0)
            {
                 ReturnBulletToPool(enemyId);
            }
        }

        private void ReturnBulletToPool(int enemyId)
        {
            _enemies[enemyId].KillEnemy();
            _enemies[enemyId].ReturnToPool -= ReturnBulletToPool;
            _enemies[enemyId].TakeDamage -= TakeDamage;
            _poolManager.Return(_enemies[enemyId].gameObject);
            _enemies.Remove(enemyId);
            _enemyRunTimeData.EnemyRunTimeData.Remove(enemyId);
        }
    }
}