using System;
using Game.Scripts.Materials;
using UnityEngine;

namespace Game.Scripts.Unit
{
    public class ResourceDetector : MonoBehaviour
    {
        public event Action<Resource> OnAddResource;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Resource resource))
            {
                OnAddResource?.Invoke(resource);
            }
        }
    }
}