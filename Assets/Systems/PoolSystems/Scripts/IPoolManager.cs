using UnityEngine;


namespace PoolSystems.Scripts
{
    public interface IPoolManager
    {
        GameObject Get(string poolID);

        void Return(GameObject obj);
        T Get<T>(string poolID) where T : Component;
    }
}
