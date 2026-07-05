using EndlessRoadSystem.Scripts.Core.Interfaces;
using EndlessRoadSystem.Scripts.Data.VO;
using UnityEngine;

namespace EnemySystem.Scripts.Data.RunTime
{
    [CreateAssetMenu(menuName = "Road/Road Data")]
    internal class CD_Road : ScriptableObject, IRoadConfig
    {
        [SerializeField] RoadVO _roadVO;

        public RoadVO RoadVO => _roadVO;
    }
}