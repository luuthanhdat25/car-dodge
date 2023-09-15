using System;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private float velocity = 1f;
    private Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = velocity * Vector2.down;
    }

    private void FixedUpdate()
    {
        
    }
}
