using Game.Scripts.Resource.Enums;
using UnityEngine;

namespace Game.Scripts.Resource.ResourceData
{
    [CreateAssetMenu(fileName = "ResourceInfo", menuName = "Gameplay/New ResourceInfo")]
    public class ResourceInfo : ScriptableObject
    {
        [SerializeField] private string _title;
        [SerializeField] private GameObject _resourcePrefab;
        [SerializeField] private ResourceType _resourceType;

        public string Title => _title;
        public GameObject ResourcePrefab => _resourcePrefab;
        public ResourceType ResourceType => _resourceType;
    }
}