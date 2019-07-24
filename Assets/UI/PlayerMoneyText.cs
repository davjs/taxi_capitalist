using System.Linq;
using Taxi;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerMoneyText : MonoBehaviour
    {
        public string PlayerId;

        private Player _player;
        private Text _text;

        void Awake()
        {
            _text = GetComponent<Text>();
            _player = FindPlayerWithId(PlayerId);
        }

        void Update()
        {
            _text.text = "$" + _player.Money;
        }

        private Player FindPlayerWithId(string id)
        {
            return GameObject.FindGameObjectsWithTag("Player")
                .Select(p => p.GetComponent<Player>())
                .First(p => p.Id.Equals(id));
        }
    }
}