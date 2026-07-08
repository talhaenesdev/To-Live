using EnemySystem.Scripts.Core.Interfaces;
using EnemySystem.Scripts.Data.VOs;
using EnemySystem.Scripts.Enums;
using UnityEngine;

namespace EnemySystem.Scripts.Data.Config
{
    [CreateAssetMenu(menuName = "Enemy/Enemy Data")]
    internal class CD_Enemy : ScriptableObject, IEnemyConfig
    {
        [SerializeField] private SerializableDictionary<int, EnemyVO> _enemyData;
        [SerializeField] private Vector3 _minSpawnPosition;
        [SerializeField] private Vector3 _maxSpawnPosition;
        [SerializeField] private float _spawnTime;




        public SerializableDictionary<int, EnemyVO> EnemyData => _enemyData;
        public Vector3 MinSpawnPosition => _minSpawnPosition;
        public Vector3 MaxSpawnPosition => _maxSpawnPosition;
        public float SpawnTime => _spawnTime;


        [SerializeField] private int _enemyId; 
        [SerializeField] private EnemyType _enemyType;
        [SerializeField] private string _name;
        [SerializeField] private float _startHealth;
        [SerializeField] private Vector3 _startPosition;

        public void AddEnemy()
        {
            EnemyVO enemyVO = new EnemyVO
            {
                EnemyType = _enemyType,
                Name = _name,
                StartHealth = _startHealth,
            };

            EnemyData.Add(_enemyId, enemyVO);
        }
    }
}