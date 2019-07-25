using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMeshObject : MonoBehaviour
{
    public float durationTime = 1f;

    private void Start()
    {
        Destroy(this.gameObject, durationTime);
        StartCoroutine(Thingy());
    }

    private IEnumerator Thingy()
    {
        for (int i = 0; i < 300; i++)
        {
            transform.Translate(Vector3.up * 0.25f, Space.World);
            yield return null;
        }
    }
}
