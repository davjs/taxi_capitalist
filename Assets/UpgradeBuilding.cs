using System.Collections;
using System.Collections.Generic;
using Taxi;
using UnityEngine;

public enum Upgrade {
    Speed,
    Size
}

public class UpgradeBuilding : MonoBehaviour {
    public int Cost = 50;
    public float SpeedIncrease = 500f;
    public Upgrade? CurrentUpgrade = Upgrade.Speed;
    public GameObject SizeIcon;
    public GameObject SpeedIcon;
    public TextMesh PriceTag;

    private void Start() {
        ClearUpgrade();
        Invoke("GetNewUpgrade", 5f);
    }

    private void OnTriggerEnter(Collider other) {
        var player = other.gameObject.GetComponentInParent<Player>();
        var taxiController = other.gameObject.GetComponentInParent<PlayerRigidbodyMovementController>();
        var personHolder = other.gameObject.GetComponentInParent<TaxiPersonHolder>();
        if (!taxiController || !personHolder || player.Money < Cost || CurrentUpgrade == null) return;

        if (CurrentUpgrade == Upgrade.Speed && !player.SpeedUpgrade) {
            taxiController.velocity += SpeedIncrease;
            player.Money -= Cost;
            player.SpeedUpgrade = true;
            ClearUpgrade();
            Invoke("GetNewUpgrade", 0.5f);
        }

        if (CurrentUpgrade == Upgrade.Size) {
            personHolder.Capacity += 1;
            player.Money -= Cost;
            ClearUpgrade();
            Invoke("GetNewUpgrade", 5f);
        }
    }

    private void ClearUpgrade() {
        CurrentUpgrade = null;
        PriceTag.text = "";
        SizeIcon.SetActive(false);
        SpeedIcon.SetActive(false);
    }

    private void GetNewUpgrade() {
        CurrentUpgrade = (Upgrade) Random.Range(0, 2);
        PriceTag.text = Cost + "$";
        if (CurrentUpgrade == Upgrade.Size) {
            SizeIcon.SetActive(true);
        }
        if (CurrentUpgrade == Upgrade.Speed) {
            SpeedIcon.SetActive(true);            
        }
    }
}