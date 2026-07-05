using PlayerControllerSystem.Scripts.Data.VOs;
using PlayerControllerSystem.Scripts.Entities;
using UnityEngine;

namespace PlayerControllerSystem.Scripts.Data.Config
{
    [CreateAssetMenu(menuName = "Player/Player RunTime Data")]
    internal class RD_Player : ScriptableObject, IPlayerRunTime
    {
        [SerializeField]
        private PlayerRVO _playerRunTimeData;

        public PlayerRVO PlayerRunTimeData
        {
            get => _playerRunTimeData;
            set => _playerRunTimeData = value;
        }

    }
}