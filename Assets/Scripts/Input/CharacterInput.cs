using UnityEngine;

namespace Input
{
    public interface CharacterInput
    {        
        Vector3 GetDirection();
        Vector2 GetRotationDirection();
        bool IsJumping();
    }
}