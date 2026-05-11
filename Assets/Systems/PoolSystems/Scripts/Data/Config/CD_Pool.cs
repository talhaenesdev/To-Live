using PoolSystems.Scripts.Data.VOs;
using System.Collections.Generic;
using UnityEngine;

namespace PoolSystems.Scripts.Data.Config
{
    [CreateAssetMenu(menuName = "Pool/Pool Data")]
    internal class CD_Pool : ScriptableObject
    {
        public List<PoolVO> PoolObject;
    }
}