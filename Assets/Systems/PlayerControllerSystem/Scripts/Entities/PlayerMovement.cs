using Assets.Systems.PlayerControllerSystem.Scripts.Entities;
using UnityEngine;
using Zenject;

namespace PlayerControllerSystem.Scripts.Entities
{
    public class PlayerMovement : MonoBehaviour
    {
        [Inject] private IPlayerConfig _playerData;
        [Inject] private IPlayerRunTime _playerRunTimeData;

        private void Awake()
        {
            SetPlayerPosition();
        }

        private void Update()
        {
            MoveForward();
            SetPlayerPosition();
        }

        private void MoveForward()
        {
            transform.position +=
                transform.forward *
                _playerData.PlayerData.Speed *
                Time.deltaTime;
        }

        private void SetPlayerPosition()
        {
            _playerRunTimeData.PlayerRunTimeData.Vector3 = transform.position;
        }
    }
}