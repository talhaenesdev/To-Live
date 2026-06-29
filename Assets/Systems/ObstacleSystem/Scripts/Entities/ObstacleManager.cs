
using EnemySystem.Scripts.Data.VOs;
using PoolSystems.Scripts;
using UnityEngine;
using Zenject;

namespace ObstacleSystem.Scripts.Entities
{
    public class ObstacleManager : MonoBehaviour
    {
        #region PoolSystem
        [Inject] private PoolManager _poolManager;
        #endregion

        private void Start()
        {
           
        }
    }
}