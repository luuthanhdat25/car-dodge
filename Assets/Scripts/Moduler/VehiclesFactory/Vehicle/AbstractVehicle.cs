using System;
using UnityEngine;

namespace Moduler.VehiclesFactory.Vehicle
{
    public abstract class AbstractVehicle : RepeatMonoBehaviour
    {
        [SerializeField] protected VehicleMovement vehicleMovement;
        private new Collider2D collider2D;
        
        private void OnEnable()
        {
            collider2D.enabled = true;
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            LoadVehicleMovementComponent();
            LoadCollider2DComponent();
        }

        private void LoadVehicleMovementComponent()
        {
            if (this.vehicleMovement != null) return;
            this.vehicleMovement = GetComponent<VehicleMovement>();
        }
        
        private void LoadCollider2DComponent()
        {
            if (this.collider2D != null) return;
            this.collider2D = GetComponent<Collider2D>();
        }
        
        public void SetSpeed(float speed) => this.vehicleMovement.SetSpeedMove(speed);
    }
}