using System;
using System.Collections.Generic;
using UnityEngine;

namespace Moduler.VehiclesFactory
{
    public abstract class AbstractSpawnVehiclesFactory : MonoBehaviour
    {
        protected Dictionary<IVehicle, Transform> vehicleDictionary;

        protected virtual void Awake()
        {
            vehicleDictionary = new Dictionary<IVehicle, Transform>();
        }

        public abstract void Spawn();
        protected abstract IVehicle GetVehicle();
    }
}