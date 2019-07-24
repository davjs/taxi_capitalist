using UnityEngine;

namespace Taxi
{
    public class PlayerStockBuyer : MonoBehaviour
    {
        private Player _player;
        private Market.Market _market;

        public void Awake()
        {
            _player = GetComponent<Player>();
            var marketGameObject = GameObject.FindGameObjectWithTag("Market");
            _market = marketGameObject.GetComponent<Market.Market>();
        }

        public void Update()
        {
            if (Input.GetButtonDown(_player.Id + "_Player_Primary") && _market.StockPrice <= _player.Money)
            {
                _market.BuyStock(_player);
            }
        }
    }
}