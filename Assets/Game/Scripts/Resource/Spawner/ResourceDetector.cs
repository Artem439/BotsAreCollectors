using System;
using UnityEngine;

namespace Game.Scripts.Resource.Spawner
{
    public class ResourceDetector : MonoBehaviour
    {
        public event Action<int> CountChanged;
        
        private int _count;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Resource _))
            {
                _count++;
                CountChanged?.Invoke(_count);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Resource _))
            {
                _count--;
                CountChanged?.Invoke(_count);
            }
        }
    }
}