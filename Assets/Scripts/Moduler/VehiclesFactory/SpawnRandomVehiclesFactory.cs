using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Moduler.VehiclesFactory
{
    public class SpawnRandomVehiclesFactory : AbstractSpawnVehiclesFactory
    {
        [SerializeField] private List<Transform> vehicleTransformList;
        [SerializeField] private Transform spawnPointTransform;

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

        private void Start() => InvokeRepeating("Spawn", 0f, 1f);

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
            IVehicle newVehicle = vehicleTransformList[Random.Range(0, vehicleTransformList.Count)].GetComponent<IVehicle>();
            return newVehicle != null ? newVehicle : null;
        }
    }
}