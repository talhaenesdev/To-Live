using EnemySystem.Scripts.Data.VOs;
using UnityEngine;

namespace EnemySystem.Scripts.Core.Interfaces
{
    internal interface IEnemyConfig
    {
        SerializableDictionary<int, EnemyVO> EnemyData { get; }
        Vector3 MinSpawnPosition { get; }
        Vector3 MaxSpawnPosition { get; }
        float SpawnTime { get; }
    }
}
