using Unity.Mathematics;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _playerHead;
        [SerializeField] private Transform _mainCamera;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _angularSpeed;
        [SerializeField] private float _sensitivity;
        private float _gravity;
        private float _rotationX = 0f;
        
        private Character _character;

        private void Awake()
        {
            _gravity = Physics.gravity.y;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void Configure(Character character)
        {
            _character = character;
        }
        
        public void Rotate(Vector2 direction)
        {
            if (direction.Equals(Vector3.zero)) return;

            RotateCharacter(direction);
            RotateCamera(direction);
        }

        private void RotateCamera(Vector2 direction)
        {
            direction *= _sensitivity * Time.deltaTime;
            _rotationX -= direction.y;
            _rotationX = Mathf.Clamp(_rotationX, -90, 90);
            _mainCamera.localRotation = quaternion.Euler(_rotationX, 0, 0);
            float newYAngle = _character.MyTransform.eulerAngles.y;
            Vector3 currentEulerAngles = _mainCamera.localEulerAngles;
            currentEulerAngles.y = newYAngle;
            _mainCamera.eulerAngles = currentEulerAngles;
        }

        private void RotateCharacter(Vector3 direction)
        {
            direction *= _angularSpeed * Time.deltaTime;

            _character.MyTransform.Rotate(Vector3.up * direction.x);
        }

        public void Move(Vector3 direction)
        {
            var movementDirection = _character.MyTransform.right * direction.x +
                                    _character.MyTransform.forward * direction.z;

            // _characterController.Move(movementDirection * (_movementSpeed * Time.deltaTime));
            
            var destination = movementDirection * (_movementSpeed * Time.deltaTime);
            var appliedGravity = _characterController.isGrounded ? 0f : -9.81f;
            var gravityForce = new Vector3(0, appliedGravity, 0);
            
            _characterController.Move(destination + gravityForce);
        }
    }
}