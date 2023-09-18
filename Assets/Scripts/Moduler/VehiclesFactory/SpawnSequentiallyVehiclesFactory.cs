using System.Collections.Generic;
using UnityEngine;

namespace Moduler.VehiclesFactory
{
    public class SpawnSequentiallyVehiclesFactory : AbstractSpawnVehiclesFactory
    {
        private int index;       

        public override Transform Spawn()
        {
            IVehicle newVehicle = GetVehicle();
            if(newVehicle == null) Debug.LogError("newVehicle dose not exist");
            Transform trans = VehicleObjectPooling.Instance.GetTransform(newVehicle);
            return trans;
        }

        protected override IVehicle GetVehicle()
        {
            IVehicle newVehicle = null;
            List<Transform> vehicleTransformList = VehicleObjectPooling.Instance.GetPrefabList();
            if (index < vehicleTransformList.Count) {
                newVehicle = vehicleTransformList[index].GetComponent<IVehicle>();
            }else {
                newVehicle = vehicleTransformList[0].GetComponent<IVehicle>();
                index = 0;
            }
            index++;
            return newVehicle;
        }
    }
}