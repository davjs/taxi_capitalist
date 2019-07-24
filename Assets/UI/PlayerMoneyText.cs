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

        void Start()
        {    
            _player = FindPlayerWithId(PlayerId);
            
            _text = GetComponent<Text>();
            _text.color = _player.GetColor();
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