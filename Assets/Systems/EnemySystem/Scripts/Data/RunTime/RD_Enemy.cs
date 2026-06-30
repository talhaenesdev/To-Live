using EnemySystem.Scripts.Core.Interfaces;
using EnemySystem.Scripts.Data.VOs;
using UnityEngine;

namespace EnemySystem.Scripts.Data.RunTime
{
    [CreateAssetMenu(menuName = "Enemy/Enemy RunTime Data")]
    internal class RD_Enemy : ScriptableObject, IEnemyRuntime
    {

        [SerializeField] private SerializableDictionary<int, EnemyRVO> _enemyRunTimeData;

        public SerializableDictionary<int, EnemyRVO> EnemyRunTimeData => _enemyRunTimeData;
    }
}