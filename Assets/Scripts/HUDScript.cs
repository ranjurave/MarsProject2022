using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HUDScript : MonoBehaviour {
    //[SerializeField]
    TextMeshProUGUI Coin;

    //[SerializeField]
    RocketScript rocketScript;

    void Start()
    {
        //rocketScript = FindObjectOfType<RocketScript>();
        //Coin = FindObjectOfType<TextMeshProUGUI>();
    }

    void Update()
    {
        Coin.text = "Coins Collected : " + rocketScript.CoinsCollected.ToString();
    }
}
