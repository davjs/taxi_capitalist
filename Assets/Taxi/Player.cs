using UnityEngine;

namespace Taxi {
    public class Player : MonoBehaviour {
        public int Money = 0;
        public int Stocks = 0;
        public bool SpeedUpgrade = false;
        public string Id = "1";
        public float collisionForce = 50;

        private Rigidbody rb;

        private void Start() {
            rb = GetComponent<Rigidbody>();
        }

        public void EarnMoney(int money) {
            Money += money;
            TextMeshManager.InstantiateText(transform.position, "+" + money + "$", Id);
        }

        public Color GetColor() {
            if (Id.Equals("1")) {
                return new Color(1, 86 / 255f, 86 / 255f);
            }

            if (Id.Equals("2")) {
                return new Color(86 / 255f, 1, 1);
            }

            if (Id.Equals("3")) {
                return new Color(1, 86 / 255f, 1);
            }

            if (Id.Equals("4")) {
                return Color.yellow;
            }

            return Color.black;
        }

        public void AddStock(int stocks) {
            Stocks += stocks;
        }

        public void SpendMoney(int amount) {
            Money -= amount;
        }

        private void OnCollisionEnter(Collision collision) {
            if (collision.gameObject.tag == "Player") {
                var player1Speed = rb.velocity.magnitude;
                var player2Speed = collision.rigidbody.velocity.magnitude;
                var player2 = collision.gameObject.GetComponent<Player>();
                if (player1Speed > player2Speed) {
                    var transaction = Mathf.Round(0.01f * player2.Money);
                    EarnMoney((int) transaction);
                    player2.EarnMoney((int) -transaction);
                }
                else {
                    var transaction = Mathf.Round(0.01f * Money);
                    EarnMoney((int) transaction);
                    player2.EarnMoney((int) transaction);
                }

                rb.AddExplosionForce(collisionForce, collision.GetContact(0).point, 2f);
            }
        }

        public string GetColorName() {
            if (Id.Equals("1")) {
                return "Red";
            }

            if (Id.Equals("2")) {
                return "Cyan";
            }

            if (Id.Equals("3")) {
                return "Purple";
            }

            if (Id.Equals("4")) {
                return "Yellow";
            }

            return "Black";
        }

        public int CalculateInterest(int value) {
            return (int) ((Stocks / 100.0f) * value);
        }
    }
}