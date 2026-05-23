using EnemySystem.Scripts.Enums;
using UnityEngine;

namespace EnemySystem.Scripts.Data.VOs
{
    [System.Serializable]
    public class EnemyVO
    {
        public EnemyType EnemyType;
        public string Name;
        public int Health;
        public Vector3 StartPosition;
    }
}