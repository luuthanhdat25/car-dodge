using System.Collections.Generic;
using UnityEngine;

namespace Moduler.VehiclesFactory
{
    public class SpawnSequentiallyVehiclesFactory : AbstractSpawnVehiclesFactory
    {
        private int index;       

        public override Transform Spawn()
        {
            IVehicleProduct newVehicleProduct = GetVehicle();
            if(newVehicleProduct == null) Debug.LogError("newVehicle dose not exist");
            Transform trans = VehicleObjectPooling.Instance.GetTransform(newVehicleProduct);
            return trans;
        }

        protected override IVehicleProduct GetVehicle()
        {
            IVehicleProduct newVehicleProduct = null;
            List<Transform> vehicleTransformList = VehicleObjectPooling.Instance.GetPrefabList();
            if (index < vehicleTransformList.Count) {
                newVehicleProduct = vehicleTransformList[index].GetComponent<IVehicleProduct>();
            }else {
                newVehicleProduct = vehicleTransformList[0].GetComponent<IVehicleProduct>();
                index = 0;
            }
            index++;
            return newVehicleProduct;
        }
    }
}