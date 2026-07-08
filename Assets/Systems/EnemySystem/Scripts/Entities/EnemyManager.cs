using EnemySystem.Scripts.Core.Interfaces;
using EnemySystem.Scripts.Data.VOs;
using PlayerControllerSystem.Scripts.Entities;
using PoolSystems.Scripts;
using UnityEngine;
using Zenject;

namespace EnemySystem.Scripts.Entities
{
    public class EnemyManager : MonoBehaviour
    {
        #region EnemySystem
        [Inject] private IEnemyConfig _enemyData;
        [Inject] private IEnemyRuntime _enemyRunTimeData;
        #endregion

        #region PoolSystem
        [Inject] private IPoolManager _poolManager;
        #endregion

        [Inject] private IPlayerRunTime _playerRunTimeData;

        #region EnemyMap
        private SerializableDictionary<int,Obstacle> _enemies = new SerializableDictionary<int, Obstacle>();
        #endregion

        private float _timer;

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _enemyData.SpawnTime)
            {
                _timer = 0f;
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            var enemyCount = _enemyData.EnemyData.Count;
            _enemyRunTimeData.EnemyRunTimeData.Clear();

            for (int i = 0; i < enemyCount; i++)
            {
                var enemy = _poolManager.Get<Obstacle>("MainEnemy");

                enemy.SetName(_enemyData.EnemyData[0].Name);
                enemy.SetHealthText(_enemyData.EnemyData[0].StartHealth);

                enemy.SetPosition(GetRandomPosition());
                enemy.SetId(i);
                enemy.CreateEnemy();
                enemy.ReturnToPool += ReturnEnemyToPool;
                enemy.TakeDamage += TakeDamage;

                EnemyRVO enemyRVO = new EnemyRVO()
                {
                    Health = _enemyData.EnemyData[0].StartHealth,
                };

                _enemyRunTimeData.EnemyRunTimeData.Add(i, enemyRVO);
                _enemies.Add(i, enemy);
            }
        }

        private Vector3 GetRandomPosition()
        {
            return new Vector3(
                Random.Range(_playerRunTimeData.PlayerRunTimeData.Vector3.x + _enemyData.MinSpawnPosition.x, _playerRunTimeData.PlayerRunTimeData.Vector3.x + _enemyData.MaxSpawnPosition.x),
                Random.Range(_playerRunTimeData.PlayerRunTimeData.Vector3.y + _enemyData.MinSpawnPosition.y, _playerRunTimeData.PlayerRunTimeData.Vector3.y + _enemyData.MaxSpawnPosition.y),
                Random.Range(_playerRunTimeData.PlayerRunTimeData.Vector3.z + _enemyData.MinSpawnPosition.z, _playerRunTimeData.PlayerRunTimeData.Vector3.z + _enemyData.MaxSpawnPosition.z));
        }

        private void TakeDamage(int enemyId, float damage)
        {
            _enemyRunTimeData.EnemyRunTimeData[enemyId].Health -= damage;
            _enemies[enemyId].SetHealthText(_enemyRunTimeData.EnemyRunTimeData[enemyId].Health);
            _enemies[enemyId].DamageModel();

            if (_enemyRunTimeData.EnemyRunTimeData[enemyId].Health <= 0)
            {
                 ReturnEnemyToPool(enemyId);
            }
        }

        private void ReturnEnemyToPool(int enemyId)
        {
            _enemies[enemyId].KillEnemy();
            _enemies[enemyId].ReturnToPool -= ReturnEnemyToPool;
            _enemies[enemyId].TakeDamage -= TakeDamage;
            _poolManager.Return(_enemies[enemyId].gameObject);
            _enemies.Remove(enemyId);
            _enemyRunTimeData.EnemyRunTimeData.Remove(enemyId);
        }
    }
}