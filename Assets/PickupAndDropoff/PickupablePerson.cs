using System;
using System.Collections;
using System.Collections.Generic;
using Taxi;
using UnityEngine;
using UnityEngine.Serialization;

public class PickupablePerson : MonoBehaviour
{
    public RoadSpawner RoadSpawner;

    private void OnCollisionEnter(Collision other)
    {
        var personHolder = other.gameObject.GetComponent<TaxiPersonHolder>();
        if (personHolder)
        {
            personHolder.LoadPersons();
            RoadSpawner.SpawnDropoffPoint();
            Destroy(gameObject);
        }
    }
}