using Manager;
using UnityEngine;

namespace Moduler
{
    public class VehivlePassCounter : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;

        private const float DISTANCE_RAYCAST2D = 5f;
        
        private void Update()
        {
            if (!GameManager.Instance.IsGamePlaying()) return;
            VehicleCounting();
        }

        private void VehicleCounting()
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.right, DISTANCE_RAYCAST2D, layerMask);
            if (hits.Length == 0) return;

            foreach (RaycastHit2D raycastHit in hits)
                raycastHit.collider.enabled = false;

            ScoreManager.Instance.IncreaseScore(hits.Length);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Vector3 secondPoint = transform.position;
            secondPoint.x += DISTANCE_RAYCAST2D;
            Gizmos.DrawLine(transform.position, secondPoint);
        }
    }
}