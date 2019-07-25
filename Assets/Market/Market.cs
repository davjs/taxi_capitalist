using System;
using Taxi;
using UnityEngine;

namespace Market
{
    public class Market : MonoBehaviour
    {
        [NonSerialized] public int StockPrice = 0;

        [NonSerialized] public int StockQt = 10;

        [NonSerialized] public Player LeadingPlayer;

        public void BuyStock(Player player)
        {
            player.AddStock(StockQt);

            if (!LeadingPlayer || player.Stocks > LeadingPlayer.Stocks)
            {
                LeadingPlayer = player;
            }

            player.SpendMoney(StockPrice);

            //StockQt = (int) Math.Max(StockQt + 1, Math.Round(StockQt * 1.1));
            StockPrice = (int) Math.Round((StockPrice * 1.2) / 10) * 10;
        }

        public bool GameHasEnded()
        {
            if (!LeadingPlayer) return false;

            return LeadingPlayer.Stocks >= 100;
        }

        public string GetLeadingPlayerId()
        {
            return LeadingPlayer.Id;
        }
    }
}