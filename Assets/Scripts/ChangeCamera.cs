using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject setCamera;
    private bool cameraOn = true;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            setCamera.SetActive(!setCamera.activeInHierarchy);
        }
    }
}
