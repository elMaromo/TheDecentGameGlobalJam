using System;
using Input;
using UnityEngine;

namespace Player
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private MovementController _movementController;
        
        private CharacterInput _input;
        
        private Transform _myTransform;
        public Transform MyTransform => _myTransform;

        private void Awake()
        {
            _movementController.Configure(this);
            _input = new UnityInput();
            _myTransform = transform;
        }
        
        private void Update()
        {
            var direction = _input.GetDirection();
            var rotationDirection = _input.GetRotationDirection();
            _movementController.Move(direction);
            _movementController.Rotate(rotationDirection);

            _movementController.ApplyGravity();
            if (_input.IsJumping())
            {
                _movementController.Jump();
            }
        }
    }
}