using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInputController : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float gizmoSize = 4;
    public bool isOrbiting = false;

    public void Update()    //Read inputs and distribute to other scripts
    {
            horizontal = Input.GetAxis("Controller_Left_Horizontal");
            Debug.Log(horizontal);
            vertical = Input.GetAxis("Controller_Left_Vertical");
       
    }

    private void OnDrawGizmos()
    {
        var directionVector = new Vector3(horizontal, 0, vertical);
        var size = Mathf.Min(1, directionVector.magnitude); //Caps var size to max 1

        if (size >= float.Epsilon)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(this.transform.position, gizmoSize);
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(this.transform.position, size * gizmoSize);
        }

        // Draw each component of the input
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, this.transform.position + Vector3.right * horizontal * gizmoSize);
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(this.transform.position, this.transform.position + Vector3.forward * vertical * gizmoSize);
        // Show the sum of both components
        Gizmos.color = Color.white;
        Gizmos.DrawLine(this.transform.position, this.transform.position + directionVector * gizmoSize);
    }
}
