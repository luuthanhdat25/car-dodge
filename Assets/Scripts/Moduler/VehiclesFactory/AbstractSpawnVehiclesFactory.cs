using Moduler.VehiclesFactory.Vehicle;
using UnityEngine;

namespace Moduler.VehiclesFactory
{
    public abstract class AbstractSpawnVehiclesFactory : MonoBehaviour
    {
        public abstract Transform Spawn();
        protected abstract AbstractVehicle GetVehicle();
    }
}