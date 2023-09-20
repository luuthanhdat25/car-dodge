using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Moduler.VehiclesFactory
{
    public class SpawnRandomVehiclesFactory : AbstractSpawnVehiclesFactory
    {
        public override Transform Spawn()
        {
            IVehicleProduct newVehicleProduct = GetVehicle();
            if(newVehicleProduct == null) Debug.LogError("newVehicle dose not exist");
            Transform trans = VehicleObjectPooling.Instance.GetTransform(newVehicleProduct);
            return trans;
        }

        protected override IVehicleProduct GetVehicle()
        {
            List<Transform> vehicleTransformList = VehicleObjectPooling.Instance.GetPrefabList();
            IVehicleProduct newVehicleProduct = vehicleTransformList[Random.Range(0, vehicleTransformList.Count)].GetComponent<IVehicleProduct>();
            return newVehicleProduct;
        }
    }
}