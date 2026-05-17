using UnityEngine;

namespace Game.Scripts.Base.Spawner
{
    public class GetSpawnCoordinates : MonoBehaviour
    {
        [SerializeField] private Collider _spawnArea;
        [SerializeField] [Min(1f)] private float _margin;

        public Vector3 GetSpawnPoint()
        {
            float spawnCoordinatesX = Random.Range(_spawnArea.bounds.min.x + _margin, _spawnArea.bounds.max.x - _margin);
            float spawnCoordinatesY = Random.Range(_spawnArea.bounds.min.y + _margin, _spawnArea.bounds.max.y - _margin);
            float spawnCoordinatesZ = Random.Range(_spawnArea.bounds.min.z + _margin, _spawnArea.bounds.max.z - _margin);

            return new Vector3(spawnCoordinatesX, spawnCoordinatesY, spawnCoordinatesZ);
        }
    }
}