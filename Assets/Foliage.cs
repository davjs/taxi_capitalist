using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foliage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var rigidbody = other.gameObject.GetComponentInParent<Rigidbody>();
        if (rigidbody && rigidbody.velocity.magnitude > 10)
        {
            rigidbody.velocity = rigidbody.velocity * .01f;
        }
    }
}