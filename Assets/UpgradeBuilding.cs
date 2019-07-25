using System.Collections;
using System.Collections.Generic;
using Taxi;
using UnityEngine;

public class UpgradeBuilding : MonoBehaviour {
    public int Cost = 50;
    public float SpeedIncrease = 500f;

    private void OnTriggerEnter(Collider other) {
        var player = other.gameObject.GetComponentInParent<Player>();
        var taxiController = other.gameObject.GetComponentInParent<PlayerRigidbodyMovementController>();
        if (taxiController && player.Money >= Cost && !player.SpeedUpgrade) {
            taxiController.velocity += SpeedIncrease;
            player.Money -= Cost;
            player.SpeedUpgrade = true;
        }
    }
}