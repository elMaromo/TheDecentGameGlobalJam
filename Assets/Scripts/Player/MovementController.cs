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
        [SerializeField] private float _jumpForce;
        private float _gravity;
        private float _rotationX = 0f;
        private Vector3 _jumpVelocity;

        private Character _character;

        private void Awake()
        {
            _jumpVelocity = new Vector3();
            _gravity = 20f;
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
            _rotationX -= direction.y * _sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);
            _mainCamera.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);

            var newYAngle = _character.MyTransform.eulerAngles.y;
            var currentEulerAngles = _mainCamera.localEulerAngles;
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


            var destination = movementDirection * (_movementSpeed * Time.deltaTime);

            _characterController.Move(destination);
        }

        public void ApplyGravity()
        {
            if (!_characterController.isGrounded)
            {
                _jumpVelocity.y -= _gravity * Time.deltaTime;
            }
            else
            {
                _jumpVelocity.y = -2f;
            }

            _characterController.Move(_jumpVelocity * Time.deltaTime);
        }

        public void Jump()
        {
            if (!_characterController.isGrounded) return;

            _jumpVelocity.y = Mathf.Sqrt(2f * _jumpForce * _gravity);
        }
    }
}