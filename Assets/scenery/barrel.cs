using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float explosiveForce = 100.0f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.useGravity = true;
            rb.AddExplosionForce(explosiveForce, transform.position, 1.0f);
        }

    }
}
