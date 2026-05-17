using System;
using System.Collections.Generic;
using Game.Scripts.Materials;
using UnityEngine;

namespace Game.Scripts.Unit
{
    [RequireComponent(typeof(ResourceDetector))]
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int _capacity;
    
        private ResourceDetector _detector;
        
        private List<Resource> _resources;

        private bool _isFilled = false;
        
        public event Action<bool> OnFilled;

        private void Awake()
        {
            _detector = GetComponent<ResourceDetector>();
            
            _resources = new List<Resource>(_capacity);
        }

        private void OnEnable()
        {
            _detector.OnAddResource += OnAddResource;
        }

        private void OnDisable()
        {
            _detector.OnAddResource -= OnAddResource;
        }
        
        private void OnAddResource(Resource resource)
        {
            if (_resources.Count >= _capacity)
                return;
    
            _resources.Add(resource);
            resource.PickUp();
    
            if (_resources.Count >= _capacity)
                OnFilled?.Invoke(true);
        }
    }
}