using EnemySystem.Scripts.Data.VOs;

namespace EnemySystem.Scripts.Core.Interfaces
{
    internal interface IEnemyRuntime
    {
        SerializableDictionary<int, EnemyRVO> EnemyRunTimeData { get; }
    }
}
