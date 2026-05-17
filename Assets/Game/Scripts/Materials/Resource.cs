using System;
using Game.Scripts.Interfaces;
using Game.Scripts.Materials.ResourceData;
using UnityEngine;

namespace Game.Scripts.Materials
{
    public class Resource : MonoBehaviour, ISpawnable<Resource>
    {
        [SerializeField] private ResourceInfo _resourceInfo;
        
        public ResourceInfo ResourceInfo => _resourceInfo;
        
        public event Action<Resource> Released;
        
        public event Action<Resource> PickedUp;
        
        public void Reset(Vector3 position)
        {
            
        }
        
        public void PickUp()
        {
            PickedUp?.Invoke(this);
            gameObject.SetActive(false);
        }
    }
}