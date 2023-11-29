using System;
using UnityEngine;

public class InGround : MonoBehaviour
{
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Drop>() != null)
        {
            Destroy(other.gameObject);
            transform.localScale *= 2;
        }
    }
}
