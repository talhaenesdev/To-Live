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
        public SerializableDictionary<int, EnemyVO> EnemyData => _enemyData;

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
                StartPosition = _startPosition
            };

            EnemyData.Add(_enemyId, enemyVO);
        }
    }
}