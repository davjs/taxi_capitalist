using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Taxi;
using UnityEngine;

public class StockBar : MonoBehaviour {
    public int PlayerIndex;
    public float MaxHeight = 5.0f;
    public float StocksGoal = 100;

    private Player _player;

    private void Start() {
        _player = GameObject.FindGameObjectsWithTag("Player")
            .ElementAt(PlayerIndex)
            .GetComponent<Player>();
        var mesh = GetComponentInChildren<MeshRenderer>();
        mesh.material.color = _player.GetColor();
    }

    private void Update() {
        var height = (_player.Stocks / StocksGoal) * MaxHeight;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, height);
    }

}