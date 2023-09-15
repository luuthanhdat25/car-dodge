using System;
using UnityEngine;

namespace Moduler
{
    public class DespawnByDistanse : MonoBehaviour
    {
        [SerializeField] private float yDistance = -10.75f;

        private void FixedUpdate()
        {
            if (transform.position.y > yDistance) return;
            VehicleObjectPooling.Instance.Despawn(this.transform);
        }
    }
}