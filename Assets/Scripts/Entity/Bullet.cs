using PoolSystems.Scripts;
using UnityEngine;


public class Bullet : MonoBehaviour, IPoolable
{
    private float _speed = 20f;

    private Vector3 _moveDirection;
    public void OnDespawn()
    {

    }

    public void OnSpawn()
    {

    }

    // Pool’dan geldiðinde yön set edilir
    public void Init(Vector3 direction)
    {
        _moveDirection = direction.normalized;
    }

    void Update()
    {
        transform.position += _moveDirection * _speed * Time.deltaTime;
    }
}
