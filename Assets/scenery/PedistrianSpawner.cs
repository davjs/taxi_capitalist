using System.Threading.Tasks;
using UnityEditor.VersionControl;
using UnityEngine;

namespace scenery
{
    public class PedistrianSpawner : MonoBehaviour
    {
        private GameObject[] _spawnPoints;

        public void Awake()
        {
            _spawnPoints = GameObject.FindGameObjectsWithTag("PedestrianSpawn");
            
        }
    }
}