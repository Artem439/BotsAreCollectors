using System;
using UnityEngine;

namespace Game.Scripts.Controls
{
    public class InputReader : MonoBehaviour
    {
        private const KeyCode OverviewButton = KeyCode.Mouse2;
        
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
    
        private const string MouseX = "Mouse X";
        private const string MouseY = "Mouse Y";
        
        private Vector3 _direction;
        private Vector2 _mouseLookDelta;
        
        public event Action<Vector3> Moved;
        public event Action<Vector2> Looked;

        private void Update()
        {
            float vertical = 0f;
            
            if (Input.GetKey(KeyCode.Space)) 
                vertical = 1f;
            
            if (Input.GetKey(KeyCode.LeftControl)) 
                vertical = -1f;
            
            _direction = new Vector3(Input.GetAxis(Horizontal), vertical, Input.GetAxis(Vertical));
            _mouseLookDelta = new Vector2(Input.GetAxis(MouseX), Input.GetAxis(MouseY));
        
            if(_direction.sqrMagnitude > 0f || _mouseLookDelta.sqrMagnitude > 0f)
                Moved?.Invoke(_direction);
            
            if (Input.GetKey(OverviewButton))
                Looked?.Invoke(_mouseLookDelta);
        }
    }
}