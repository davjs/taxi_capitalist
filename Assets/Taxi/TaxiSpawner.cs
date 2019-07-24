using System;
using System.Collections.Generic;
using System.Linq;
using Taxi;
using UnityEngine;

public class TaxiSpawner : MonoBehaviour
{
    public GameObject Taxi;

    public String[] Colors = new[] {"Red", "Cyan", "Yellow", "Purple"};

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
            var colorNameToUse = taxiPlayer.GetColorName();
            foreach (var color in Colors)
            {
                if (color != colorNameToUse)
                {
                    var taxiColoredMesh = taxi.transform.Find(color + "Taxi");
                    taxiColoredMesh.gameObject.SetActive(false);
                }
            }

//            taxi.GetComponentInChildren<MeshRenderer>().material
//                .SetColor("_BaseColor", taxiPlayer.GetColor());
            nextPlayerId += 1;
        }
    }

    private static IEnumerable<Vector3> GetTaxiSpawnPoints()
    {
        return GameObject.FindGameObjectsWithTag("TaxiSpawn").Select(spawn => spawn.transform.position);
    }
}