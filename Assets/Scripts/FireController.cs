using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{

    public GameObject fire;

    private bool isColl = false;

    void Update()
    {
        if (isColl)
        {
            Debug.Log("fuego");
        }
        if (!isColl)
        {
<<<<<<< HEAD
            //Debug.Log("no quemado");
=======
            Debug.Log("no quemado");
>>>>>>> main
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColl = true;
        }
    }
}
