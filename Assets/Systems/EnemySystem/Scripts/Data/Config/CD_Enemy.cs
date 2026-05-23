using EnemySystem.Scripts.Data.VOs;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem.Scripts.Data.Config
{
    [CreateAssetMenu(menuName = "Enemy/Enemy Data")]
    internal class CD_Enemy : ScriptableObject
    {
        public List<EnemyVO>  EnemyData;
    }
}