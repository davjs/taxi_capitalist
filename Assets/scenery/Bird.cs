using System.Collections;
using UnityEngine;

namespace scenery
{
    public class Bird : MonoBehaviour
    {
        private Vector3 _startPosition;
        private Quaternion _startRotation;

        public void Awake()
        {
            _startPosition = transform.position;
            _startRotation = transform.rotation;
            Invoke("Respawn", 20);

            GetComponentInChildren<Animator>().speed = Random.Range(0.6f, 1f);

            StartCoroutine(Respawn());
        }

        public void Update()
        {
            transform.position += transform.forward * Time.deltaTime * 5f;
            transform.Rotate(0, Random.Range(0, 2) * Time.deltaTime, 0);
        }

        private IEnumerator Respawn()
        {
            yield return new WaitForSeconds(30);

            while (true)
            {
                transform.position = _startPosition;
                transform.rotation = _startRotation;
                yield return new WaitForSeconds(30);
            }
        }
    }
}