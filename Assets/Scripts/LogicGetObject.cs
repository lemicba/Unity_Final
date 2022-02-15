using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicGetObject : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo))
            {
                if(hitInfo.collider.gameObject.tag == "Object" && hitInfo.collider.gameObject.GetComponent<PowerUps>().destroyWithCursor == true)
                {
                    hitInfo.collider.gameObject.GetComponent<PowerUps>().Efecto();
                    Destroy(hitInfo.collider.gameObject);
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Object" && other.GetComponent<PowerUps>().destroyAutomatic == true)
        {
            other.GetComponent<PowerUps>().Efecto();
            Destroy(other.gameObject);
        }

        if(other.tag == "object")
        {
            if(Input.GetMouseButtonDown(1) && other.GetComponent<PowerUps>().destroyWithCursor == false)
            {
                other.GetComponent<PowerUps>().Efecto();
                Destroy(other.gameObject);
            }
        }
    }
}
