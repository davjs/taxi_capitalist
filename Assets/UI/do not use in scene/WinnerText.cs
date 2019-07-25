using UnityEngine;
using UnityEngine.UI;

public class WinnerText : MonoBehaviour
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
        if (_market.GameHasEnded())
        {
            var number = int.Parse(_market.GetLeadingPlayerId());
            _text.text = "Player " + number + " has won";
        }
    }
}