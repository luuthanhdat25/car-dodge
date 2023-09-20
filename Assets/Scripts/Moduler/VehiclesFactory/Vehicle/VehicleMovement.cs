using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    [SerializeField] private float speedMove;

    private void Update()
    {
        Vector3 newPosition = Vector3.down * speedMove * Time.deltaTime;
        this.transform.Translate(newPosition);
    }
    
    public void SetSpeedMove(float newSpeed) => this.speedMove = newSpeed;
}
