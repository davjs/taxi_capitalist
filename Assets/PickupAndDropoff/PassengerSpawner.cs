using System;
using System.Collections.Generic;
using System.Linq;
using Taxi;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PickupAndDropoff
{
    public class PassengerSpawner : MonoBehaviour
    {
        public GameObject Passenger;
        public GameObject Dropoff;

        private List<Vector3> FreeSpawns;
        private int _maxPassengers;
        private int _passengersOut;

        public void Awake()
        {
            var points = GameObject.FindGameObjectsWithTag("Spawn");
            FreeSpawns = points.Select(point => point.transform.position).ToList();
            _maxPassengers = FreeSpawns.Count / 2;

            SpawnPassengers();
        }

        public void SpawnPassengers()
        {
            var passengersToSpawn = _maxPassengers - _passengersOut;
            for (var i = 0; i < passengersToSpawn; i++)
            {
                var randomIndex = Random.Range(0, FreeSpawns.Count);
                var spawnPoint = FreeSpawns[randomIndex];
                FreeSpawns.RemoveAt(randomIndex);

                var passengerGameObject = Instantiate(Passenger, spawnPoint, Quaternion.Euler(0, Random.value * 360, 0));
                var passenger = passengerGameObject.GetComponent<Passenger>();
                passenger.OriginalSpawnPoint = spawnPoint;
                passenger.Spawner = this;
                _passengersOut += 1;
            }
        }

        public void RegisterPassengerPickedUpAtPointByPlayer(Vector3 originalSpawnPoint, Player player)
        {
            var dropoffLocation = GetDropoffLocation();
            var dropoffGameObject = Instantiate(Dropoff, dropoffLocation, Random.rotation);
            var dropoff = dropoffGameObject.GetComponent<Dropoff>();
            dropoff.OriginalSpawnPoint = dropoffLocation;
            dropoff.Spawner = this;
            dropoff.Player = player;
            dropoff.GetComponentInChildren<MeshRenderer>().material.SetColor("_BaseColor", player.GetColor());

            FreeSpawns.Add(originalSpawnPoint);
            _passengersOut -= 1;
        }

        public void RegisterDropoffAtPointByPlayer(Vector3 originalSpawnPoint)
        {
            SpawnPassengers();
            FreeSpawns.Add(originalSpawnPoint);
        }

        private Vector3 GetDropoffLocation()
        {
            var randomIndex = Random.Range(0, FreeSpawns.Count);
            var spawnPoint = FreeSpawns[randomIndex];
            FreeSpawns.RemoveAt(randomIndex);

            return spawnPoint;
        }
    }
}