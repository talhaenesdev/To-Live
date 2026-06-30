using EnemySystem.Scripts.Data.VOs;

namespace EnemySystem.Scripts.Core.Interfaces
{
    internal interface IEnemyConfig
    {
        SerializableDictionary<int, EnemyVO> EnemyData { get; }
    }
}
