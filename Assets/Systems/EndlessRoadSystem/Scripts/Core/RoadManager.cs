using EndlessRoadSystem.Scripts.Core.Interfaces;
using EndlessRoadSystem.Scripts.Entities;
using PlayerControllerSystem.Scripts.Entities;
using PoolSystems.Scripts;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace EndlessRoadSystem.Scripts.Core
{
    public class RoadManager : MonoBehaviour
    {
        [Inject] private IPoolManager _poolManager;
        [Inject] private IPlayerRunTime _playerRunTimeData;
        [Inject] private IRoadConfig _roadConfig;

        [SerializeField] private List<RoadEntity> _roadColliders = new();

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            CreateFirstRoad();
        }

        private void AddListener(RoadEntity road)
        {
            road.OnSpawn();
            road.PlayerEntered += OnPlayerEntered;
        }

        private void RemoveListener(RoadEntity road)
        {
            road.OnDespawn();
            road.PlayerEntered -= OnPlayerEntered;
        }

        private void OnPlayerEntered(RoadEntity road)
        {
            int index = _roadColliders.IndexOf(road);

            if (index > 0)
            {
                RemoveListener(_roadColliders[index - 1]);
                _poolManager.Return(_roadColliders[index - 1].gameObject);
                _roadColliders.RemoveAt(index - 1);
            }

            CreateRoad();
        }

        private void CreateFirstRoad()
        {
            RoadEntity roadEntity = _poolManager.Get<RoadEntity>("Way1");
            roadEntity.SetPosition(GetRoadYPosition());
            AddListener(roadEntity);
            _roadColliders.Add(roadEntity);
        }

        private void CreateRoad()
        {
            RoadEntity roadEntity = _poolManager.Get<RoadEntity>("Way1");
            roadEntity.SetPosition(GetRoadYAndZPosition());
            AddListener(roadEntity);
            _roadColliders.Add(roadEntity);
        }

        private Vector3 GetRoadYAndZPosition()
        {
            Vector3 position = _playerRunTimeData.PlayerRunTimeData.Vector3;
            position.y += _roadConfig.RoadVO.YPosition;
            position.z += _roadConfig.RoadVO.ZPosition;
            return position;
        }

        private Vector3 GetRoadYPosition()
        {
            Vector3 position = _playerRunTimeData.PlayerRunTimeData.Vector3;
            position.y += _roadConfig.RoadVO.YPosition;
            return position;
        }
    }
}