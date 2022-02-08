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
                if(hitInfo.collider.gameObject.tag == "Object" && hitInfo.collider.gameObject.GetComponent<Inventary>().destroyWithCursor == true)
                {
                    //Debug.Log(hitInfo.collider.gameObject.tag);
                    hitInfo.collider.gameObject.GetComponent<Inventary>().Efecto();
                    Destroy(hitInfo.collider.gameObject);
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Object" && other.GetComponent<Inventary>().destroyAutomatic == true)
        {
            other.GetComponent<Inventary>().Efecto();
            Destroy(other.gameObject);
        }

        if(other.tag == "object")
        {
            if(Input.GetMouseButtonDown(1) && other.GetComponent<Inventary>().destroyWithCursor == false)
            {
                other.GetComponent<Inventary>().Efecto();
                Destroy(other.gameObject);
            }
        }
    }
}
