using System;
using UnityEngine;

namespace Game.Scripts.Materials.Spawner
{
    public class ResourceDetector : MonoBehaviour
    {
        public event Action<int> CountChanged;
        
        private int _count;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Resource resource))
            {
                _count++;
                resource.PickedUp += OnResourcePickedUp;
                CountChanged?.Invoke(_count);
            }
        }
        
        private void OnResourcePickedUp(Resource resource)
        {
            resource.PickedUp -= OnResourcePickedUp;
            _count--;
            CountChanged?.Invoke(_count);
        }
    }
}