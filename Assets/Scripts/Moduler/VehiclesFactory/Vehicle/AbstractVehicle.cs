using UnityEngine;

namespace Moduler.VehiclesFactory.Vehicle
{
    public abstract class AbstractVehicle : RepeatMonoBehaviour
    {
        [SerializeField] protected VehicleMovement vehicleMovement;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            if (this.vehicleMovement != null) return;
            this.vehicleMovement = GetComponent<VehicleMovement>();
        }
    }
}