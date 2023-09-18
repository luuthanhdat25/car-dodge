using System;
using UnityEngine;

public class VehicleMoving : MonoBehaviour
{
    [SerializeField] private float speedMove = 3f;

    private void Update()
    {
        Vector3 newPosition = Vector3.down * speedMove * Time.deltaTime;
        this.transform.Translate(newPosition);
    }
}
