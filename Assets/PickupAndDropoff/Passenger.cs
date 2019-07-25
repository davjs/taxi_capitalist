using Taxi;
using UnityEngine;

namespace PickupAndDropoff
{
    public class Passenger : MonoBehaviour
    {
        public Vector3 OriginalSpawnPoint;
        public PassengerSpawner Spawner;

        private Light _light;
        private Rigidbody _body;

        public void Awake()
        {
            _light = GetComponentInChildren<Light>();

            _body = GetComponent<Rigidbody>();
            _body.isKinematic = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            var otherPlayer = other.gameObject.GetComponent<Player>();
            if (!otherPlayer) return;

            var personHolder = otherPlayer.GetComponent<TaxiPersonHolder>();
            if (!personHolder.CanFitMore())
            {
                transform.Rotate(Vector3.right, 90);
                Invoke("DestroySelf", 5.0f);
                GetComponent<Collider>().enabled = false;
                _light.color = Color.red;
                _light.intensity = 10;

                _body.isKinematic = false;
                GetComponentInChildren<Animator>().enabled = false;
                _body.AddForce(((Vector3.up * 2) + (Vector3.forward * Random.value * .75f)) * .0012f, ForceMode.Impulse);

                return;
            }

            Spawner.RegisterPassengerPickedUpAtPointByPlayer(OriginalSpawnPoint, otherPlayer);

            personHolder.LoadPersons();

            DestroySelf();
        }

        private void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}