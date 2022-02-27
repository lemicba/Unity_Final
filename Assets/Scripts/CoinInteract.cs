using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInteract : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            EventManager.TriggerCollectCoins();
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        EventManager.OnCollectCoins += OnCollectCoinsHandler;
    }

    private void OnDisable()
    {
        EventManager.OnCollectCoins -= OnCollectCoinsHandler;
    }

    private void OnCollectCoinsHandler()
    {
        Debug.Log("Has agarrado una moneda");
    }

}
