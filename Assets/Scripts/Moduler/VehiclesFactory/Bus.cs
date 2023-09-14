using UnityEngine;

namespace Moduler.VehiclesFactory
{
    public class Bus : MonoBehaviour,IVehicle
    {
        public void Move(float speed)
        {
            
        }

        public Transform GetTransform()
        {
            throw new System.NotImplementedException();
        }
    }
}