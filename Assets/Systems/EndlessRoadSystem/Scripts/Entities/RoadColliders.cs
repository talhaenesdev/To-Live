using System;
using UnityEngine;

namespace EndlessRoadSystem.Scripts.Entities
{
    internal class RoadColliders : MonoBehaviour
    {
        public event Action PlayerEntered;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;

            PlayerEntered?.Invoke();
        }
    }
}