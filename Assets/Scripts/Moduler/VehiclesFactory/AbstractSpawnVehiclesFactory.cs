using System;
using System.Collections.Generic;
using UnityEngine;

namespace Moduler.VehiclesFactory
{
    public abstract class AbstractSpawnVehiclesFactory : MonoBehaviour
    {
        public abstract Transform Spawn();
        protected abstract IVehicle GetVehicle();
    }
}