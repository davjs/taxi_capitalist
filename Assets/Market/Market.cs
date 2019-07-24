using System;
using Taxi;
using UnityEngine;

namespace Market
{
    public class Market : MonoBehaviour
    {
        public int StockPrice = 100;
        public int StockQt = 1;

        public void BuyStock(Player player)
        {
            player.AddStock(StockQt);
            player.SpendMoney(StockPrice);

            StockQt = (int) Math.Max(StockQt + 1, Math.Round(StockQt * 1.2));
            StockPrice = (int) Math.Round((StockPrice * 1.5) / 10) * 10;
        }
    }
}