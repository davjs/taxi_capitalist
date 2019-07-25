using System.Linq;
using Taxi;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MarketPriceText : MonoBehaviour
{
    private TextMeshPro _text;
    private Market.Market _market;

    void Start()
    {
        _text = GetComponentInChildren<TextMeshPro>();

        _market = GameObject.FindGameObjectWithTag("Market").GetComponent<Market.Market>();
    }

    void Update()
    {
        _text.text = _market.StockQt + "% Share \n$" + _market.StockPrice;
    }

    private Player FindPlayerWithId(string id)
    {
        return GameObject.FindGameObjectsWithTag("Player")
            .Select(p => p.GetComponent<Player>())
            .First(p => p.Id.Equals(id));
    }
}