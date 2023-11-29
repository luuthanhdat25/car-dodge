using RepeatUtil.DesignPattern.SingletonPattern;
using Moduler.VehiclesFactory.Vehicle;
using Moduler.VehiclesFactory;

using System.Collections.Generic;
using Manager;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Moduler
{
    public class VehicleSpawner : Singleton<VehicleSpawner>
    {
        [SerializeField] private List<Transform> spawnPointList;
        [SerializeField] private AbstractSpawnVehiclesFactory factory;
        
        private int[] spawnPointArrayCount = new int[4];
        private float timer = 0;
        private int previusIndex;

        private void Start() => timer = GameManager.Instance.GetSpawnSpeed();

        private void FixedUpdate()
        {
            if (!GameManager.Instance.IsGamePlaying()) return;
            timer -= Time.fixedDeltaTime;
            if (timer <= 0)
            {
                timer = GameManager.Instance.GetSpawnSpeed();
                Spawn();
            }
        }

        public void Spawn()
        {
            Transform newVehicle = factory.Spawn();
            int indexPoint = GetIndexSpawnPoint();
            
            //Create despawn abstract(DespawnByDistanse and DespawnByDistanse Dead) and get abstractVehicle
            newVehicle.GetComponent<DespawnByDistanse>().SetIndexSpawnPoint(indexPoint);
            newVehicle.GetComponent<AbstractVehicle>().SetSpeed(GameManager.Instance.GetVehicleSpeed());
            
            newVehicle.transform.position = spawnPointList[indexPoint].position;
            spawnPointArrayCount[indexPoint]++;
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
                    case 1: previusIndex = 3; break;
                    case 3: previusIndex = 3; break;
                    case 5: previusIndex = 0; break;
                }
            }
            
            return minimumIndex;
        }

        public void DespawnSpawnPointArrayCount(int index) => spawnPointArrayCount[index]--;
    }
}