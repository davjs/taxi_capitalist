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

            var playerId = nextPlayerId.ToString();
            var taxiPlayer = taxi.GetComponent<Player>();
            taxiPlayer.Id = playerId;
            taxi.GetComponentInChildren<MeshRenderer>().material
                .SetColor("_BaseColor", taxiPlayer.GetColor());
            nextPlayerId += 1;
        }
    }

    private static IEnumerable<Vector3> GetTaxiSpawnPoints()
    {
        return GameObject.FindGameObjectsWithTag("TaxiSpawn").Select(spawn => spawn.transform.position);
    }
}