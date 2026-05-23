using System;
using UnityEngine;

namespace ShootingSystem.Scripts.Entities
{
    internal class Collider : MonoBehaviour
    {
        public Action ObjectTrigger;
        private void OnTriggerEnter(UnityEngine.Collider other)
        {
            if (other.CompareTag("CanTrigger"))
            {
                ObjectTrigger?.Invoke();
            }
        }
    }
}