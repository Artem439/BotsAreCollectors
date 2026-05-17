using System;
using Game.Scripts.Interfaces;
using Game.Scripts.Resource.ResourceData;
using UnityEngine;

namespace Game.Scripts.Resource
{
    public class Resource : MonoBehaviour, ISpawnable<Resource>
    {
        [SerializeField] private ResourceInfo _resourceInfo;
        
        public ResourceInfo ResourceInfo => _resourceInfo;
        
        public event Action<Resource> Released;
        
        public void Reset(Vector3 position)
        {
            
        }
    }
}