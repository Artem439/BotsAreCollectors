using System.Collections;
using Game.Scripts.Base.Spawner;
using UnityEngine;

namespace Game.Scripts.Resource.Spawner
{
    [RequireComponent(typeof(ResourceDetector))]
    public class ResourceSpawner : SpawnerBase<Resource>
    {
        [SerializeField] private float _delay;
        [SerializeField] [Min(1f)] private int _capacity;
        [SerializeField] private GetSpawnCoordinates _spawnCoordinates;

        private ResourceDetector _detector;
        
        private int _currentCount;

        private void Awake()
        {
            _detector = GetComponent<ResourceDetector>();
        }

        private void OnEnable()
        {
            _detector.CountChanged += OnCountChanged;
        }

        private void OnDisable()
        {
            _detector.CountChanged -= OnCountChanged;
        }

        private void Start()
        {
            StartCoroutine(SpawnRoutine());
        }
        
        protected override void Spawn()
        {
            Vector3 spawnPoint = _spawnCoordinates.GetSpawnPoint();
            
            Resource entity = _entitiesPool.Get();
            
            entity.Reset(spawnPoint);
            
            entity.Released += OnReleased;
        }
        
        private IEnumerator SpawnRoutine()
        {
            WaitForSeconds delay = new WaitForSeconds(_delay);

            while (enabled)
            {
                if (_currentCount < _capacity)
                {
                    Spawn();
                }
                yield return delay;
            }
        }

        private void OnCountChanged(int count)
        {
            _currentCount = count;
        }
    }
}