using Taxi;
using UnityEngine;

namespace PickupAndDropoff
{
    public class Passenger : MonoBehaviour
    {
        public Vector3 OriginalSpawnPoint;
        public PassengerSpawner Spawner;

        private void OnCollisionEnter(Collision other)
        {
            var otherPlayer = other.gameObject.GetComponent<Player>();
            if (otherPlayer)
            {
                Spawner.RegisterPassengerPickedUpAtPointByPlayer(OriginalSpawnPoint, otherPlayer);

                var personHolder = otherPlayer.GetComponent<TaxiPersonHolder>();
                personHolder.LoadPersons();

                Destroy(gameObject);
            }
        }
    }
}