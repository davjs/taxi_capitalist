using System.Data.SqlTypes;
using UnityEngine;

namespace Taxi
{
    public class Player : MonoBehaviour
    {
        public int Money = 100;
        public string Id = "Red";

        public void EarnMoney(int money)
        {
            Money += money;
        }
    }
}