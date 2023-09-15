using System.Collections.Generic;
using UnityEngine;

namespace Moduler.VehiclesFactory
{
    public class SpawnSequentiallyVehiclesFactory : AbstractSpawnVehiclesFactory
    {
        [SerializeField] private List<Transform> vehicleTransformList;
        [SerializeField] private Transform spawnPointTransform;
        [SerializeField] private float timeRepeat;
        private int index = 0;        

        protected override void Awake()
        {
            base.Awake();
            foreach (Transform transform in vehicleTransformList)
            {
                IVehicle vehicle = transform.GetComponent<IVehicle>();
                if (vehicle != null) 
                    vehicleDictionary.TryAdd(vehicle, transform);
            }
        }

        private void Start() => InvokeRepeating("Spawn", 0f, timeRepeat);

        public override void Spawn()
        {
            IVehicle newVehicle = GetVehicle();
            if (!vehicleDictionary.ContainsKey(newVehicle)) return;
            Transform transform = Instantiate(vehicleDictionary[newVehicle]);
            if (transform != null)
            {
                transform.position = spawnPointTransform.position;
                Debug.Log("Spawned");
            }
            else Debug.Log("Transform Null");
        }

        protected override IVehicle GetVehicle()
        {
            IVehicle newVehicle = null;
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