using EnemySystem.Scripts.Data.VOs;
using UnityEngine;

namespace EnemySystem.Scripts.Data.RunTime
{
    [CreateAssetMenu(menuName = "Enemy/Enemy RunTime Data")]
    internal class RD_Enemy : ScriptableObject
    {
        public SerializableDictionary<int, EnemyRVO> EnemyRunTimeData;
    }
}