using PoolSystems.Scripts;
using UnityEngine;
using Zenject;

namespace ObstacleSystem.Scripts.Entities
{
    public class ObstacleManager : MonoBehaviour
    {
        #region PoolSystem
        [Inject] private IPoolManager _poolManager;
        #endregion

        private void Start()
        {
           
        }
    }
}