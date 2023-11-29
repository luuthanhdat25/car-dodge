using Manager;
using UnityEngine;

namespace Moduler.Player
{
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        
        private const float DISTANCE_RAYCAST2D = 0.6f;
        private const float DISTANCE_OF_TWO_RAYCAST = 0.5f;

        private void Update()
        {
            if (!GameManager.Instance.IsGamePlaying()) return;
            Interact();
        }

        private void Interact()
        {
            Vector2 rayCastOrigin = transform.position;
            RaycastHit2D hit1 = Physics2D.Raycast(rayCastOrigin, Vector2.right, DISTANCE_RAYCAST2D, layerMask);
            rayCastOrigin.y -= DISTANCE_OF_TWO_RAYCAST;
            RaycastHit2D hit2 = Physics2D.Raycast(rayCastOrigin, Vector2.right, DISTANCE_RAYCAST2D, layerMask);
            if (!hit1 && !hit2) return;

            GameManager.Instance.GameOver();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 rayCastOneSecondPoint = transform.position;
            rayCastOneSecondPoint.x += DISTANCE_RAYCAST2D;
            Gizmos.DrawLine(transform.position, rayCastOneSecondPoint);
            
            Vector3 rayCastTwoFirstPoint = transform.position;
            rayCastTwoFirstPoint.y -= DISTANCE_OF_TWO_RAYCAST;
            Vector3 rayCastTwoSecondPoint = rayCastOneSecondPoint;
            rayCastTwoSecondPoint.y -= DISTANCE_OF_TWO_RAYCAST;
            Gizmos.DrawLine(rayCastTwoFirstPoint, rayCastTwoSecondPoint);
        }
    }
}