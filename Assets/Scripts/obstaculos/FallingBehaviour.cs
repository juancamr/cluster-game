using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBehavior : MonoBehaviour
{
    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - (rb.mass * 0.5f), rb.velocity.z);
    }
}
