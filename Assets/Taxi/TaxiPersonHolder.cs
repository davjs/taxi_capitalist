using UnityEngine;

namespace Taxi
{
    public class TaxiPersonHolder : MonoBehaviour
    {
        private int _loadedPassengers;

        private const int Price = 100;
        private const int Capacity = 1;

        public void LoadPersons()
        {
            _loadedPassengers += 1;
        }

        public void UnloadPersons()
        {
            _loadedPassengers -= 1;

            var player = GetComponent<Player>();
            player.EarnMoney(Capacity * Price);

            var allPlayers = GameObject.FindGameObjectsWithTag("Player");

            foreach (var obj in allPlayers)
            {
                obj.GetComponent<Player>().EarnInterest(Capacity * Price);
            }
        }

        public bool CanFitMore()
        {
            return _loadedPassengers < Capacity;
        }
    }
}