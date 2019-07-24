using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject PickupPrefab;
    public GameObject DropoffPrefab;

    private List<Vector3> _spawnPoints;

    private void Awake()
    {
        var points = GameObject.FindGameObjectsWithTag("Spawn");
        _spawnPoints = points.Select(point => point.transform.position).ToList();
    }

    private void Start()
    {
        SpawnPickupPoint();
    }

    public void SpawnDropoffPoint()
    {
        var point = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
        var dropoffObject = Instantiate(DropoffPrefab, point, Quaternion.identity);

        var dropoff = dropoffObject.GetComponent<Dropoff>();
        dropoff.RoadSpawner = this;
    }

    public void SpawnPickupPoint()
    {
        var point = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
        var pickupObject = Instantiate(PickupPrefab, point, Quaternion.identity);

        var pickupablePerson = pickupObject.GetComponent<PickupablePerson>();
        pickupablePerson.RoadSpawner = this;
    }
}