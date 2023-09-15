using System;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private float velocity = 2f;
    private Rigidbody2D rigidbody2D;

    private void OnEnable()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = velocity * Vector2.down;
    }
}
