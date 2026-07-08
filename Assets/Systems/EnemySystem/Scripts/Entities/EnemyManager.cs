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
        [Inject] private IEnemyConfig _enemyConfigData;
        [Inject] private IEnemyRuntime _enemyRunTimeData;
        #endregion

        #region PoolSystem
        [Inject] private IPoolManager _poolManager;
        #endregion

        [Inject] private IPlayerRunTime _playerRunTimeData;

        #region EnemyMap
        [SerializeField] private SerializableDictionary<int,Obstacle> _enemies = new SerializableDictionary<int, Obstacle>();
        #endregion

        int _enemiesCount = 0;
        private float _timer;

        private void Start()
        {
            _enemyRunTimeData.EnemyRunTimeData.Clear();
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _enemyConfigData.SpawnTime)
            {
                _timer = 0f;
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            var enemy = _poolManager.Get<Obstacle>("MainEnemy");

            enemy.SetName(_enemyConfigData.EnemyData[0].Name);
            enemy.SetHealthText(_enemyConfigData.EnemyData[0].StartHealth);
            enemy.SetPosition(GetRandomPosition());
            enemy.CreateEnemy();
            enemy.SetId(_enemiesCount);
            enemy.ReturnToPool += ReturnEnemyToPool;
            enemy.TakeDamage += TakeDamage;

            EnemyRVO enemyRVO = new EnemyRVO()
            {
                Health = _enemyConfigData.EnemyData[0].StartHealth,
            };

            _enemies.Add(_enemiesCount, enemy);
            _enemyRunTimeData.EnemyRunTimeData.Add(_enemiesCount, enemyRVO);
            _enemiesCount++;
        }

        private Vector3 GetRandomPosition()
        {
            return new Vector3(
                Random.Range(_playerRunTimeData.PlayerRunTimeData.Vector3.x + _enemyConfigData.MinSpawnPosition.x, _playerRunTimeData.PlayerRunTimeData.Vector3.x + _enemyConfigData.MaxSpawnPosition.x),
                Random.Range(_playerRunTimeData.PlayerRunTimeData.Vector3.y + _enemyConfigData.MinSpawnPosition.y, _playerRunTimeData.PlayerRunTimeData.Vector3.y + _enemyConfigData.MaxSpawnPosition.y),
                Random.Range(_playerRunTimeData.PlayerRunTimeData.Vector3.z + _enemyConfigData.MinSpawnPosition.z, _playerRunTimeData.PlayerRunTimeData.Vector3.z + _enemyConfigData.MaxSpawnPosition.z));
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
            _enemies[enemyId].ResetModel();
            _enemies[enemyId].KillEnemy();
            _enemies[enemyId].ReturnToPool -= ReturnEnemyToPool;
            _enemies[enemyId].TakeDamage -= TakeDamage;
            _poolManager.Return(_enemies[enemyId].gameObject);
            _enemies.Remove(enemyId);
            _enemyRunTimeData.EnemyRunTimeData.Remove(enemyId);
        }
    }
}