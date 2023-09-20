using UnityEngine;

namespace Moduler
{
    public class DespawnByDistanse : MonoBehaviour
    {
        private const float Y_COORDINATE_DESPAWN = -7;
        private int indexSpawnPoint;

        public void SetIndexSpawnPoint(int index) => this.indexSpawnPoint = index;

        private void FixedUpdate()
        {
            if (transform.position.y > Y_COORDINATE_DESPAWN) return;
            VehicleSpawner.Instance.DespawnSpawnPointArrayCount(indexSpawnPoint);
            VehicleObjectPooling.Instance.Despawn(this.transform);
        }
    }
}