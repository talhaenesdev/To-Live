using Assets.Systems.PoolSystems.Scripts;
using PoolSystems.Scripts.Data.VOs;
using System.Collections.Generic;
using UnityEngine;

namespace PoolSystems.Scripts.Data.Config
{
    [CreateAssetMenu(menuName = "Pool/Pool Data")]
    internal class CD_Pool : ScriptableObject , IPoolConfig
    {
        [SerializeField] private List<PoolVO> _poolObject;

        public List<PoolVO> PoolObject => _poolObject;
    }
}