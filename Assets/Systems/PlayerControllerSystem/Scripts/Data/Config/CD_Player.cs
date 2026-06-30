using Assets.Systems.PlayerControllerSystem.Scripts.Entities;
using PlayerControllerSystem.Scripts.Data.VOs;
using UnityEngine;

namespace PlayerControllerSystem.Scripts.Data.Config
{
    [CreateAssetMenu(menuName = "Player/Player Data")]
    internal class CD_Player : ScriptableObject, IPlayerConfig
    {
        [SerializeField] private PlayerVO _playerData; 

        public PlayerVO PlayerData => _playerData;
    }
}