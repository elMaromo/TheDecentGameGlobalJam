using UnityEngine;

namespace Input
{
    public class UnityInput : CharacterInput
    {
        public Vector3 GetDirection()
        {
            var horizontal = UnityEngine.Input.GetAxisRaw("Horizontal");
            var vertical = UnityEngine.Input.GetAxisRaw("Vertical");
            return new Vector3(horizontal, 0, vertical);
        }
        

        public Vector2 GetRotationDirection()
        {
            var mouseX = UnityEngine.Input.GetAxis("Mouse X");
            var mouseY = UnityEngine.Input.GetAxis("Mouse Y");
            return new Vector3(mouseX, mouseY);
        }

        public bool IsJumping()
        {
            return UnityEngine.Input.GetKeyDown(KeyCode.Space);
        }
    }
}