using System.Collections.Generic;
using Moduler.VehiclesFactory.Vehicle;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Moduler.VehiclesFactory
{
    public class SpawnRandomVehiclesFactory : AbstractSpawnVehiclesFactory
    {
        public override Transform Spawn()
        {
            AbstractVehicle newVehicleProduct = GetVehicle();
            if(newVehicleProduct == null) Debug.LogError("newVehicle dose not exist");
            Transform trans = VehicleObjectPooling.Instance.GetTransform(newVehicleProduct);
            return trans;
        }

        protected override AbstractVehicle GetVehicle()
        {
            List<Transform> vehicleTransformList = GetPrefabList();
            AbstractVehicle newVehicleProduct = vehicleTransformList[Random.Range(0, vehicleTransformList.Count)].GetComponent<AbstractVehicle>();
            return newVehicleProduct;
        }

        private List<Transform> GetPrefabList() => VehicleObjectPooling.Instance.GetPrefabList();
    }
}