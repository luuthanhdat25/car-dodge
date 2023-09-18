using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Moduler.VehiclesFactory
{
    public class SpawnRandomVehiclesFactory : AbstractSpawnVehiclesFactory
    {
        public override Transform Spawn()
        {
            IVehicle newVehicle = GetVehicle();
            if(newVehicle == null) Debug.LogError("newVehicle dose not exist");
            Transform trans = VehicleObjectPooling.Instance.GetTransform(newVehicle);
            return trans;
        }

        protected override IVehicle GetVehicle()
        {
            List<Transform> vehicleTransformList = VehicleObjectPooling.Instance.GetPrefabList();
            IVehicle newVehicle = vehicleTransformList[Random.Range(0, vehicleTransformList.Count)].GetComponent<IVehicle>();
            return newVehicle;
        }
    }
}