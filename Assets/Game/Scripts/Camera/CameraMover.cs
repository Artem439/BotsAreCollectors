using System;
using Game.Scripts.Controls;
using UnityEngine;

namespace Game.Scripts.Camera
{
    [RequireComponent(typeof(CharacterController))]
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private float _moveSpeed = 3;
    
        private CharacterController _characterController;
    
        private Vector3 _direction;
    
        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void OnEnable()
        {
            _inputReader.Moved += OnMove;
        }

        private void OnDisable()
        {
            _inputReader.Moved -= OnMove;
        }
        
        private void Update()
        {
            Move();
            
            Reset();
        }

        private void Move()
        {
            Vector3 horizontal = transform.TransformDirection(new Vector3(_direction.x, 0f, _direction.z));
            Vector3 vertical = new Vector3(0f, _direction.y, 0f);
            
            _characterController.Move((horizontal + vertical) * _moveSpeed * Time.deltaTime);
        }

        private void Reset()
        {
            _direction = Vector3.zero;
        }

        private void OnMove(Vector3 direction)
        {
            _direction = direction;
        }
    }
}