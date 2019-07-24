using UnityEngine;

namespace Taxi
{
    public class TaxiPersonHolder : MonoBehaviour
    {
        private const int Price = 100;
        private const int Capacity = 1;

        public void LoadPersons()
        {
        }

        public void UnloadPersons()
        {
            var player = GetComponent<Player>();
            player.EarnMoney(Capacity * Price);
        }
    }
}