using System.Collections.Generic;
using Moduler.VehiclesFactory.Vehicle;
using UnityEngine;

namespace Moduler.VehiclesFactory
{
    public class SpawnSequentiallyVehiclesFactory : AbstractSpawnVehiclesFactory
    {
        private int index;       

        public override Transform Spawn()
        {
            AbstractVehicle newVehicleProduct = GetVehicle();
            if(newVehicleProduct == null) Debug.LogError("newVehicle dose not exist");
            Transform trans = VehicleObjectPooling.Instance.GetTransform(newVehicleProduct);
            return trans;
        }

        protected override AbstractVehicle GetVehicle()
        {
            AbstractVehicle newVehicleProduct = null;
            List<Transform> vehicleTransformList = VehicleObjectPooling.Instance.GetPrefabList();
            if (index < vehicleTransformList.Count) {
                newVehicleProduct = vehicleTransformList[index].GetComponent<AbstractVehicle>();
            }else {
                newVehicleProduct = vehicleTransformList[0].GetComponent<AbstractVehicle>();
                index = 0;
            }
            index++;
            return newVehicleProduct;
        }
    }
}