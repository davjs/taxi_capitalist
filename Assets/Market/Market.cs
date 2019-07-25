using System;
using Taxi;
using UnityEngine;

namespace Market
{
    public class Market : MonoBehaviour
    {
        [NonSerialized] public int StockPrice = 100;

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

            StockPrice = (int) Math.Max(StockPrice + 10, Math.Round((StockPrice * 1.15) / 10) * 10);

            AudioManager.instance.Play("PurchaseStock");
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