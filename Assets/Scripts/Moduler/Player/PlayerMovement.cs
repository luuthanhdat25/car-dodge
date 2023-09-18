using UnityEngine;

namespace Moduler.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private float distanceMove = 1.43f;
        private float leftLimitMove = -2.145f;
        private float rightLimitMove = 2.145f;

        private void LateUpdate() => MoveWithTransform();

        private void MoveWithTransform()
        {
            float horizontalInput = InputManager.Instance.GetHorizontalInputValue();
            Vector3 newPosition = GetNewPosition(horizontalInput);
            transform.parent.position = newPosition;
        }

        private Vector3 GetNewPosition(float horizontalInput)
        {
            float newXPosition = Mathf.Clamp(transform.parent.position.x + (distanceMove) * horizontalInput, 
                                                leftLimitMove, 
                                                rightLimitMove);
            
            Vector3 newPosition = transform.parent.position;
            newPosition.x = newXPosition;
            return newPosition;
        }
    }
}