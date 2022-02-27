using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeaponCharacter : MonoBehaviour
{
    public GetWeapons getWeapons;
    public int weaponNumber;
    void Start()
    {
        getWeapons = GameObject.FindGameObjectWithTag("Player").GetComponent<GetWeapons>();
    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            getWeapons.ActiveWeapons(weaponNumber);
            Destroy(gameObject);
        }
    }
}
