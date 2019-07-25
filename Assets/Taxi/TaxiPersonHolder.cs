using System.Linq;
using UnityEngine;

namespace Taxi
{
    public class TaxiPersonHolder : MonoBehaviour
    {
        private int _loadedPassengers;

        [SerializeField] private AudioClip stockPurchase;

        private const int Price = 100;
        public int Capacity = 1;

        public void LoadPersons()
        {
            _loadedPassengers += 1;
        }

        public bool CanFitMore()
        {
            return _loadedPassengers < Capacity;
        }

        public void UnloadPerson()
        {
            _loadedPassengers -= 1;

            var player = GetComponent<Player>();
            var sumMoney = Price;
            player.EarnMoney(sumMoney);

            var allPlayers = GameObject.FindGameObjectsWithTag("Player")
                .Select(x => x.GetComponent<Player>())
                .Where(x => x.Id != player.Id);

            foreach (var obj in allPlayers)
            {
                obj.EarnMoney(obj.CalculateInterest(sumMoney));
            }
            AudioManager.instance.Play("Dropoff");
        }
    }
}