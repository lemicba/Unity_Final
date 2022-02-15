using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPowers : MonoBehaviour
{
    private Dictionary<string, int> myInventoryPowers = new Dictionary<string, int>();
    private string invetoryDisplay;
    void Start()
    {
        myInventoryPowers.Add("Jump", 1);
        myInventoryPowers.Add("Big", 2);
        myInventoryPowers.Add("Speed", 3);

        invetoryDisplay = "";

        foreach (var item in myInventoryPowers)
        {
            invetoryDisplay += "PowerUps: " + item.Key + " Cantidad: " + item.Value + "\n";
            Debug.Log(invetoryDisplay);
        }
    }
}
