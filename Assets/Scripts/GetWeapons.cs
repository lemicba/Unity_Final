using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWeapons : MonoBehaviour
{
    public GameObject[] weapons;

    private void Update()
    {
        
    }
    public void ActiveWeapons(int number)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
        weapons[number].SetActive(true);
    }
}
