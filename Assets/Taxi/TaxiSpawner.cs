using System.Collections.Generic;
using System.Linq;
using Taxi;
using UnityEngine;

public class TaxiSpawner : MonoBehaviour
{
    public GameObject Taxi;

    // Start is called before the first frame update
    public void Awake()
    {
        var spawnPoints = GetTaxiSpawnPoints();

        var nextPlayerId = 1;
        foreach (var spawnPoint in spawnPoints)
        {
            var taxi = Instantiate(Taxi, spawnPoint, Quaternion.identity);

            taxi.GetComponent<Player>().Id = nextPlayerId.ToString();
            nextPlayerId += 1;
        }
    }

    private static IEnumerable<Vector3> GetTaxiSpawnPoints()
    {
        return GameObject.FindGameObjectsWithTag("TaxiSpawn").Select(spawn => spawn.transform.position);
    }
}