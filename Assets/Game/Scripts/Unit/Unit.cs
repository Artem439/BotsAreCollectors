using UnityEngine;

namespace Game.Scripts.Unit
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private float _backpackCapacity;
        
        private bool _isBusy = false;
    }
}