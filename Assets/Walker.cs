using Taxi;
using UnityEngine;

public class Walker : MonoBehaviour
{
    private Rigidbody _body;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody>();
        _body.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_body.isKinematic)
        {
            transform.position += -transform.right * 1.2f * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        var player = other.gameObject.GetComponent<Player>();

        if (player)
        {
            _body.isKinematic = false;
            GetComponent<Animator>().enabled = false;

            var rigidbody = GetComponent<Rigidbody>();
            rigidbody.AddForce(((Vector3.up) + (rigidbody.velocity * .75f)) * .0006f, ForceMode.Impulse);

            AudioManager.instance.Play("UGH");

            player.EarnMoney(1);

            Destroy(gameObject, 5);
        }
    }
}