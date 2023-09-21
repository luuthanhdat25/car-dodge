using System;
using Manager;
using RepeatUtil.DesignPattern.SingletonPattern;
using UnityEngine;

namespace Moduler
{
    public class ScoreCounter : Singleton<ScoreCounter>
    {
        public event EventHandler OnVehiclePassed;
        
        [SerializeField] private LayerMask layerMask;

        private const float DISTANCE_RAYCAST2D = 5f;
        
        private int score;
        
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

            score += hits.Length;
            OnVehiclePassed?.Invoke(this, EventArgs.Empty);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Vector3 secondPoint = transform.position;
            secondPoint.x += DISTANCE_RAYCAST2D;
            Gizmos.DrawLine(transform.position, secondPoint);
        }

        public int GetScore() => this.score;
    }
}