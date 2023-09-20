using Moduler.VehiclesFactory.Vehicle;
using UnityEngine;

namespace Moduler.VehiclesFactory
{
    public class GreenCar : AbstractVehicle, IVehicleProduct
    {
        public void SetSpeed(float speed) => this.vehicleMovement.SetSpeedMove(speed);
    }
}