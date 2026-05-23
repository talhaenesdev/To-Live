using EnemySystem.Scripts.Data.Config;
using PoolSystems.Scripts;
using UnityEngine;

namespace EnemySystem.Scripts.Entities
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private CD_Enemy _enemyData;
        [SerializeField] private PoolManager _poolManager;

        private void Start()
        {
            var enemyCount = _enemyData.EnemyData.Count;

            for (int i = 0; i < enemyCount; i++)
            {
                var enemy = _poolManager.Get<Enemy>("MainEnemy");

                enemy.SetName(_enemyData.EnemyData[i].Name);
                enemy.SetHealth(_enemyData.EnemyData[i].Health);
                enemy.SetPosition(_enemyData.EnemyData[i].StartPosition);
            }
        }
    }
}