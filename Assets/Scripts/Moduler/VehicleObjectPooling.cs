using RepeatUtil.DesignPattern.ObjectPooling;
using UnityEngine;

namespace Moduler
{
    public class VehicleObjectPooling : ListObjectPooling<IVehicle>
    {
        public static VehicleObjectPooling Instance { get; private set; }

        protected override void Awake()
        {
            if(Instance != null) Debug.LogError("VehicleObjectPooling is already initialized");
            Instance = this;
            base.Awake();
        }
    }
}