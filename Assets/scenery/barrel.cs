using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float explosiveForce = 100.0f;
    public float resetTimerLength = 10.0f;
    public GameObject lid;
    private Rigidbody lidRb;

    private Vector3 startPos;
    private Quaternion startRot;
    private Vector3 lidStartPos;
    private Quaternion lidStartRot;

    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        lidStartPos = lid.transform.position;
        lidStartRot = lid.transform.rotation;

        rb = GetComponent<Rigidbody>();
        lidRb = lid.GetComponent<Rigidbody>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.useGravity = true;
            rb.AddExplosionForce(explosiveForce, transform.position, 1.0f);
            lidRb.useGravity = true;
            lidRb.AddExplosionForce(explosiveForce / 2, lid.transform.position, 1.0f);

            StartCoroutine(ResetAfterTime(resetTimerLength));
        }
    }

    private IEnumerator ResetAfterTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        transform.SetPositionAndRotation(startPos, startRot);
        rb.isKinematic = true;
        rb.isKinematic = false;

        lid.transform.SetPositionAndRotation(lidStartPos, lidStartRot);
        lidRb.isKinematic = true;
        lidRb.isKinematic = false;
    }
}
