using Manager;
using UnityEngine;

namespace Moduler.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : RepeatMonoBehaviour
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        
        private const float DISTANCE_MOVE = 1.43f;
        private const float X_COORDINATE_MOVE_MIN = -2.145f;
        private const float X_COORDINATE_MOVE_MAX = 2.145f;
        
        private float moveSpeed;
        private bool isMoving = false;
        private Vector3 targetPosition;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            if (this.rigidbody2D != null) return;
            this.rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start() => this.rigidbody2D.gravityScale = 0;

        private void LateUpdate()
        {
            if (GameManager.Instance.IsGameOver())
            {
                rigidbody2D.velocity = Vector2.zero;
                return;
            }
            Move();
        }

        private void Move()
        {
            float horizontalInput = InputManager.Instance.GetHorizontalInputValue();

            if (!isMoving && horizontalInput != 0)
            {
                targetPosition = GetNewPosition(horizontalInput);
                isMoving = true;
            }

            if (isMoving) MoveTowardsTargetPosition();
        }

        private Vector3 GetNewPosition(float horizontalInput)
        {
            Vector3 currentPosition = transform.position;
            float newXPosition = Mathf.Clamp(currentPosition.x + (DISTANCE_MOVE) * horizontalInput, 
                X_COORDINATE_MOVE_MIN, 
                X_COORDINATE_MOVE_MAX);
            
            Vector3 newPosition = currentPosition;
            newPosition.x = newXPosition;
            return newPosition;
        }
        
        private void MoveTowardsTargetPosition()
        {
            Vector3 currentPosition = transform.position;
            Vector3 moveDirection = (targetPosition - currentPosition).normalized;
            moveSpeed = GameManager.Instance.GetPlayerMoveSpeed();
            Vector3 velocity = moveDirection * moveSpeed;
            
            rigidbody2D.velocity = velocity;

            if (Vector3.Distance(currentPosition, targetPosition) <= 0.05f)
            {
                transform.position = targetPosition;
                isMoving = false;
                rigidbody2D.velocity = Vector3.zero;
            }
        }

        public float GetMoveSpeed() => this.moveSpeed;
        
        public void SetMoveSpeed(float newMoveSpeed) => this.moveSpeed = newMoveSpeed;
    }
}