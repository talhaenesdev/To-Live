using PoolSystems.Scripts.Data.VOs;
using System.Collections.Generic;

namespace Assets.Systems.PoolSystems.Scripts
{
    internal interface IPoolConfig
    {
        List<PoolVO> PoolObject {  get; }
    }
}
