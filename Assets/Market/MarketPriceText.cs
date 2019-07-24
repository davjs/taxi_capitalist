using System.Linq;
using Taxi;
using UnityEngine;
using UnityEngine.UI;

public class MarketPriceText : MonoBehaviour
{
    private Text _text;
    private Market.Market _market;

    void Start()
    {
        _text = GetComponent<Text>();

        _market = GameObject.FindGameObjectWithTag("Market").GetComponent<Market.Market>();
    }

    void Update()
    {
        _text.text = _market.StockQt + "% stake for $" + _market.StockPrice;
    }

    private Player FindPlayerWithId(string id)
    {
        return GameObject.FindGameObjectsWithTag("Player")
            .Select(p => p.GetComponent<Player>())
            .First(p => p.Id.Equals(id));
    }
}