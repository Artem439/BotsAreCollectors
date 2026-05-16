using Game.Scripts.Controls;
using UnityEngine;

namespace Game.Scripts.Camera
{
    public class CameraRotator : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;
    
        [SerializeField] private float _sensitivity = 2.0f;
        [SerializeField] private float _maxYAngle = 90.0f;
    
        private Vector2 _mouseLookDelta;
    
        private float _rotationX;

        private void OnEnable()
        {
            _inputReader.Looked += OnLook;
        }

        private void OnDisable()
        {
            _inputReader.Looked -= OnLook;
        }

        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            float mouseX = _mouseLookDelta.x;
            float mouseY = _mouseLookDelta.y;
        
            transform.parent.Rotate(Vector3.up * mouseX * _sensitivity);
        
            _rotationX -= mouseY * _sensitivity;
        
            _rotationX = Mathf.Clamp(_rotationX, -_maxYAngle, _maxYAngle);
        
            transform.localRotation = Quaternion.Euler(_rotationX, 0.0f, 0.0f);
        
            _mouseLookDelta = Vector2.zero;
        }
        
        private void OnLook(Vector2 delta)
        {
            _mouseLookDelta = delta;
        }
    }
}