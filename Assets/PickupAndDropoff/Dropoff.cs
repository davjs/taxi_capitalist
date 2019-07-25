using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using PickupAndDropoff;
using Taxi;
using UnityEngine;

public class Dropoff : MonoBehaviour
{
    public Player Player;
    public Vector3 OriginalSpawnPoint;
    public PassengerSpawner Spawner;

    private void OnTriggerEnter(Collider other)
    {
        var otherPlayer = other.gameObject.GetComponentInParent<Player>();
        if (otherPlayer && Player.Id.Equals(otherPlayer.Id))
        {
            Spawner.RegisterDropoffAtPointByPlayer(OriginalSpawnPoint);

            var personHolder = Player.GetComponent<TaxiPersonHolder>();
            personHolder.UnloadPerson();

            Destroy(gameObject);
        }
    }
}