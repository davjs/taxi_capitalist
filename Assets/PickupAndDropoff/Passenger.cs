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
            if (!otherPlayer) return;

            var personHolder = otherPlayer.GetComponent<TaxiPersonHolder>();
            if (!personHolder.CanFitMore()) return;

            Spawner.RegisterPassengerPickedUpAtPointByPlayer(OriginalSpawnPoint, otherPlayer);

            personHolder.LoadPersons();

            Destroy(gameObject);
        }
    }
}