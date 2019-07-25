using System;
using System.Collections;
using Taxi;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public enum Upgrade
{
    Speed,
    Size
}

public class UpgradeBuilding : MonoBehaviour
{
    [NonSerialized] public int Cost = 500;
    [NonSerialized] public float SpeedIncrease = 500f;
    public Upgrade? CurrentUpgrade = Upgrade.Speed;
    public GameObject SizeIcon;
    public GameObject SpeedIcon;
    public TextMeshPro PriceTag;

    private void Start()
    {
        ClearUpgrade();
        Invoke("GetNewUpgrade", 5f);

        StartCoroutine(SwapUpgrades());
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponentInParent<Player>();
        var taxiController = other.gameObject.GetComponentInParent<PlayerRigidbodyMovementController>();
        var personHolder = other.gameObject.GetComponentInParent<TaxiPersonHolder>();
        if (!taxiController || !personHolder || player.Money < Cost || CurrentUpgrade == null) return;

        if (CurrentUpgrade == Upgrade.Speed)
        {
            taxiController.velocity += SpeedIncrease;
            player.Money -= Cost;
            player.SpeedUpgrade = true;
            ClearUpgrade();
        }

        if (CurrentUpgrade == Upgrade.Size)
        {
            personHolder.Capacity += 1;
            player.Money -= Cost;
            player.gameObject.transform.localScale *= 1.35f;
            player.gameObject.transform.position += Vector3.up * 2;

            ClearUpgrade();
        }

        AudioManager.instance.Play("Upgrade");
    }

    private void ClearUpgrade()
    {
        CurrentUpgrade = null;
        PriceTag.text = "";
        SizeIcon.SetActive(false);
        SpeedIcon.SetActive(false);
    }

    private void GetNewUpgrade()
    {
        CurrentUpgrade = (Upgrade) Random.Range(0, 2);
        PriceTag.text = "$" + Cost;
        if (CurrentUpgrade == Upgrade.Size)
        {
            SizeIcon.SetActive(true);
        }

        if (CurrentUpgrade == Upgrade.Speed)
        {
            SpeedIcon.SetActive(true);
        }
    }

    private IEnumerator SwapUpgrades()
    {
        yield return new WaitForSeconds(10);

        while (true)
        {
            ClearUpgrade();
            GetNewUpgrade();

            yield return new WaitForSeconds(10);
        }
    }
}