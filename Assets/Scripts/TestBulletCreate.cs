using PoolSystems.Scripts;
using ShootingSystem.Scripts.Entities;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class TestBulletCreate : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] private Transform _firePoint;

    [Inject] private IPoolManager _poolManager;

    void Start()
    {

    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 targetPoint = GetMouseWorldPoint();

            Shoot(targetPoint);
        }
    }

    Vector3 GetMouseWorldPoint()
    {
        Ray ray = _cam.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.point;
        }

        return Vector3.zero;
    }

    void Shoot(Vector3 targetPoint)
    {
        Bullet bullet = _poolManager.Get<Bullet>("Bullet");

        bullet.transform.position = _firePoint.position;
        bullet.Init(targetPoint,0,0,0);
    }
}