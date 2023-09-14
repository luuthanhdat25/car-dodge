using System;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private float velocity = 2f;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = velocity * Vector2.down;
    }

    private void FixedUpdate()
    {
        
    }
}
