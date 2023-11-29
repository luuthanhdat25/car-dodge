using Moduler.VehiclesFactory.Vehicle;
using RepeatUtil.DesignPattern.ObjectPooling;
using UnityEngine;

namespace Moduler
{
    public class VehicleObjectPooling : ListObjectPooling<AbstractVehicle>
    {
        public static VehicleObjectPooling Instance { get; private set; }

        private int poolSize;
        
        protected override void Awake()
        {
            if(Instance != null) Debug.LogError("VehicleObjectPooling is already initialized");
            Instance = this;
            base.Awake();
        }

        public override Transform GetTransform<T>(T instance)
        {
            poolSize++;
            return base.GetTransform(instance);
        }
        
        public override void Despawn(Transform obj)
        {
            obj.gameObject.SetActive(false);
            poolSize--;
        } 
        
        public int GetPoolSize() => poolSize;
    }
}