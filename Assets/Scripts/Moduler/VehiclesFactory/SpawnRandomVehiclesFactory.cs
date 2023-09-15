using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Moduler.VehiclesFactory
{
    public class SpawnRandomVehiclesFactory : AbstractSpawnVehiclesFactory
    {
        [SerializeField] private Transform spawnPointTransform;
        [SerializeField] private float timeRepeat;
        
        private void Start()
        {
            // foreach (Transform trans in VehicleObjectPooling.Instance.GetPrefabList())
            // {
            //     IVehicle vehicle = trans.GetComponent<IVehicle>();
            //     if (vehicle != null) 
            //         vehicleDictionary.TryAdd(vehicle, trans);
            // }
            //
            InvokeRepeating("Spawn", 0f, timeRepeat);
        }

        public override void Spawn()
        {
            IVehicle newVehicle = GetVehicle();
            // if (!vehicleDictionary.ContainsKey(newVehicle)) return;
            //Transform transform = Instantiate(vehicleDictionary[newVehicle]);
            if(newVehicle == null) Debug.LogError("newVehicle dose not exist");
            Transform trans = VehicleObjectPooling.Instance.GetTransform(newVehicle);
            if (trans != null)
            {
                trans.position = spawnPointTransform.position;
                Debug.Log("Spawned");
            }
            else Debug.Log("Transform Null");
        }

        protected override IVehicle GetVehicle()
        {
            List<Transform> vehicleTransformList = VehicleObjectPooling.Instance.GetPrefabList();
            IVehicle newVehicle = vehicleTransformList[Random.Range(0, vehicleTransformList.Count)].GetComponent<IVehicle>();
            return newVehicle;
        }
    }
}