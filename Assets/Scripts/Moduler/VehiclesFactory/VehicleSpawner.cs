using System;
using System.Collections.Generic;
using System.Linq;
using Moduler.VehiclesFactory;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Moduler
{
    public class VehicleSpawner : MonoBehaviour
    {
        public static VehicleSpawner Instance { get; private set; }
        
        [SerializeField] private List<Transform> spawnPointList;
        [SerializeField] private AbstractSpawnVehiclesFactory factory;
        [SerializeField] private float timeRepeat = 1f;
        
        private int[] spawnPointArrayCount = new int[4];
        private float timer = 0;
        private int previusIndex;

        private void Awake()
        {
            if(Instance != null) Debug.LogError("SpawnManager is already initialized");
            Instance = this;
        }

        private void Start()
        {
            timer = timeRepeat;
        }

        private void FixedUpdate()
        {
            timer -= Time.fixedDeltaTime;
            if (timer <= 0)
            {
                timer = timeRepeat;
                Transform newVehicle = factory.Spawn();
                int indexPoint = GetIndexSpawnPoint();
                newVehicle.GetComponent<DespawnByDistanse>().SetIndexSpawnPoint(indexPoint);
                newVehicle.transform.position = spawnPointList[indexPoint].position;
                spawnPointArrayCount[indexPoint]++;
                //Debug.Log(spawnPointArrayCount[0] + ", " + spawnPointArrayCount[1] + ", " + spawnPointArrayCount[2] + ", " + spawnPointArrayCount[3]);
            }
        }

        //Get the index has minimum vehicle
        private int GetIndexSpawnPoint()
        {
            int mininumVehicleCount = VehicleObjectPooling.Instance.GetPoolSize(), minimumIndex = 0;
            for (int i = 0; i < spawnPointArrayCount.Length; i++)
            {
                int count = spawnPointArrayCount[i];
                if(count == 0) return Random.Range(0, spawnPointArrayCount.Length);
                
                if (count < mininumVehicleCount)
                {
                    minimumIndex = i;
                    mininumVehicleCount = count; 
                }
            }

            if (Mathf.Abs(minimumIndex - previusIndex) == 1)
            {
                minimumIndex = previusIndex;
                switch (minimumIndex + previusIndex)
                {
                    case 1:
                        previusIndex = 3;
                        break;
                    case 3:
                        previusIndex = 3;
                        break;
                    case 5:
                        previusIndex = 0;
                        break;
                }
            }
            
            return minimumIndex;
        }

        public void DespawnSpawnPointArrayCount(int index) => spawnPointArrayCount[index]--;
    }
}