using PoolSystems.Scripts.Data.Config;
using PoolSystems.Scripts.Data.VOs;
using System.Collections.Generic;
using UnityEngine;

namespace PoolSystems.Scripts
{
    internal class PoolManager : MonoBehaviour
    {
        public static PoolManager Instance;

        [SerializeField]
        private CD_Pool database;

        private Dictionary<string, Pool> pools =
            new();

        private void Awake()
        {
            Instance = this;

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
