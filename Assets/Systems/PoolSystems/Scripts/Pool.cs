using PoolSystems.Scripts.Data.VOs;
using System.Collections.Generic;
using UnityEngine;

namespace PoolSystems.Scripts
{
    internal class Pool
    {
        private Queue<GameObject> objects =
            new();

        private PoolVO data;

        private Transform parent;

        public Pool(PoolVO data, Transform root)
        {
            this.data = data;

            parent =
                new GameObject(data.PoolID).transform;

            parent.SetParent(root);

            Warmup();
        }

        private void Warmup()
        {
            for (int i = 0; i < data.InitialSize; i++)
            {
                GameObject obj = Create();

                obj.SetActive(false);

                objects.Enqueue(obj);
            }
        }

        private GameObject Create()
        {
            GameObject obj =
                Object.Instantiate(
                    data.Prefab,
                    parent);

            PoolObject poolObject =
                obj.GetComponent<PoolObject>();

            if (poolObject == null)
                poolObject =
                    obj.AddComponent<PoolObject>();

            poolObject.PoolID =
                data.PoolID;

            return obj;
        }

        public GameObject Get()
        {
            GameObject obj;

            if (objects.Count > 0)
            {
                obj = objects.Dequeue();
            }
            else
            {
                if (!data.Expandable)
                    return null;

                obj = Create();
            }

            obj.SetActive(true);

            return obj;
        }

        public void Return(GameObject obj)
        {
            obj.SetActive(false);

            obj.transform.SetParent(parent);

            objects.Enqueue(obj);
        }
    }
}
