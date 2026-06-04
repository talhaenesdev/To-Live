using PoolSystems.Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using WeaponSystem.Scripts.Data.Config;
using WeaponSystem.Scripts.Enums;

namespace ShootingSystem.Scripts.Entities
{
    public class UIAim : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private PoolManager _poolManager;
        [SerializeField] private Camera cam;
        [SerializeField] private Transform firePoint;
        [SerializeField] private CD_Bullets _bulletData;

        [SerializeField] private List<Bullet> _bullets = new List<Bullet>();

        private void Awake()
        {

        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //Debug.Log("Clicked at: " + eventData.position);
            Vector2 screenPos = eventData.position;

            Shoot(screenPos);
        }

        void Shoot(Vector2 screenPos)
        {
            Ray ray = cam.ScreenPointToRay(screenPos);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 worldPoint = hit.point;

                SpawnBullet(worldPoint);
            }
        }

        void SpawnBullet(Vector3 target)
        {
            Bullet bullet =
                _poolManager.Get<Bullet>("Bullet" + BulletType.Normal.ToString());

            GunBarrel gunBarrel = FindAnyObjectByType<GunBarrel>();

            bullet.transform.position =
                gunBarrel.SpawnPoint.position;

            bullet.ReturnToPool += ReturnBulletToPool;
            bullet.Init(target, _bulletData.Bullets[(int)BulletType.Normal].Speed, _bulletData.Bullets[(int)BulletType.Normal].MaxDistance, _bulletData.Bullets[(int)BulletType.Normal].Damage);
            bullet.OnSpawn();


            _bullets.Add(bullet);
        }

        private void ReturnBulletToPool(Bullet bullet)
        {
            bullet.ReturnToPool -= ReturnBulletToPool;
            _poolManager.Return(bullet.gameObject);
            _bullets.Remove(bullet);
        }

        private void OnDestroy()
        {
            foreach (Bullet bullet in _bullets)
            {
                if (bullet != null)
                {
                    bullet.OnDespawn();
                }
            }
        }
    }
}