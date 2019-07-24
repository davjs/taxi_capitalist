using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor.VersionControl;
using UnityEngine;

namespace scenery
{
    public class PedistrianSpawner : MonoBehaviour
    {
        public GameObject Pedestrian;
        private IEnumerable<Transform> _spawns;

        public void Awake()
        {
            _spawns = GameObject
                .FindGameObjectsWithTag("PedestrianSpawn")
                .Select(spawn => spawn.transform);

            foreach (var spawn in _spawns)
            {
                StartCoroutine(SpawnPedestriansAtPoint(spawn, Random.Range(0, 3000)));
            }
        }


        private IEnumerator SpawnPedestriansAtPoint(Transform spawn, float delay)
        {
            yield return new WaitForSeconds(delay);

            while (true)
            {
                Instantiate(Pedestrian, spawn.position, spawn.rotation);

                yield return new WaitForSeconds(delay);
            }
        }
    }
}