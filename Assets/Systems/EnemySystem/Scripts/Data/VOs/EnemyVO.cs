using EnemySystem.Scripts.Enums;
using UnityEngine;

namespace EnemySystem.Scripts.Data.VOs
{
    [System.Serializable]
    public class EnemyVO
    {
        public EnemyType EnemyType;
        public string Name;
        public float StartHealth;
    }
}