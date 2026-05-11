
using UnityEngine;

namespace PoolSystems.Scripts.Data.VOs
{
    [System.Serializable]
    public class PoolVO
    {
        public string PoolID;
        public GameObject Prefab;
        public int InitialSize = 20;
        public bool Expandable = true;
    }

}
