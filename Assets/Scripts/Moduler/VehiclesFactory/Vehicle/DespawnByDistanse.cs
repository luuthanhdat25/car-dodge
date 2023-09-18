using System;
using UnityEngine;

namespace Moduler
{
    public class DespawnByDistanse : MonoBehaviour
    {
        [SerializeField] private float yDistance = -10.75f;
        private int indexSpawnPoint;

        public void SetIndexSpawnPoint(int index) => this.indexSpawnPoint = index;

        private void FixedUpdate()
        {
            if (transform.position.y > yDistance) return;
            VehicleSpawner.Instance.DespawnSpawnPointArrayCount(indexSpawnPoint);
            VehicleObjectPooling.Instance.Despawn(this.transform);
        }
    }
}