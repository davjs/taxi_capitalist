using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropoff : MonoBehaviour
{
    public RoadSpawner RoadSpawner;

    private void OnCollisionEnter(Collision other)
    {
        var personHolder = other.gameObject.GetComponent<TaxiPersonHolder>();
        if (personHolder)
        {
            personHolder.loadPersons();
            RoadSpawner.SpawnPickupPoint();
            Destroy(gameObject);
        }
    }
}