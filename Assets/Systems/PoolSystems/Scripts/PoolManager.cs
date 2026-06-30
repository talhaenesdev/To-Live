using Assets.Systems.PoolSystems.Scripts;
using PoolSystems.Scripts.Data.VOs;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PoolSystems.Scripts
{
    internal class PoolManager : MonoBehaviour, IPoolManager
    {
        [Inject]
        private IPoolConfig database;

        private Dictionary<string, Pool> pools =
            new();

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            foreach (PoolVO vo in database.PoolObject)
            {
                Pool pool =
                    new Pool(vo, transform);

                pools.Add(vo.PoolID, pool);
            }
        }

        public GameObject Get(string poolID)
        {
            if (!pools.TryGetValue(poolID, out Pool pool))
            {
                Debug.LogError($"Pool not found: {poolID}");
                return null;
            }

            return pool.Get();
        }

        public void Return(GameObject obj)
        {
            PoolObject poolObject =
                obj.GetComponent<PoolObject>();

            pools[poolObject.PoolID]
                .Return(obj);
        }

        public T Get<T>(string poolID) where T : Component
        {
            GameObject obj = Get(poolID);

            if (obj == null)
                return null;

            return obj.GetComponent<T>();
        }
    }
}
