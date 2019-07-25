using Taxi;
using UnityEngine;

namespace PickupAndDropoff {
    public class Passenger : MonoBehaviour {
        public Vector3 OriginalSpawnPoint;
        public PassengerSpawner Spawner;

        private void OnTriggerEnter(Collider other) {
            var otherPlayer = other.gameObject.GetComponent<Player>();
            if (!otherPlayer) return;

            var personHolder = otherPlayer.GetComponent<TaxiPersonHolder>();
            if (!personHolder.CanFitMore()) {
                transform.Rotate(Vector3.right, 90);
                Invoke("DestroySelf", 5.0f);
                GetComponent<Collider>().enabled = false;
                return;
            }

            Spawner.RegisterPassengerPickedUpAtPointByPlayer(OriginalSpawnPoint, otherPlayer);

            personHolder.LoadPersons();

            DestroySelf();
        }

        private void DestroySelf() {
            Destroy(gameObject);
        }
    }
}