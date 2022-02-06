using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{

    public GameObject puerta1;

    private Vector3 puerta1PosIn = new Vector3(2.5f, 4.5f, 30);
    private Vector3 puerta1PosFin = new Vector3(2.5f, 8, 30);
    public Animator anim;
    public bool isPress;
    public float tiempo = 3;

    private bool isCollision = false;

    void Update()
    {
        if (isCollision)
        {
            //abrirPuertas();
            anim.SetBool("isPress", true);
            Debug.Log("entro");
            timer();
        }
        if (!isCollision)
        {
            //cerrarPuertas();
            anim.SetBool("isPress", false);
            Debug.Log("no entro");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollision = true;
        }
    }

    //void abrirPuertas()
    //{
    //    puerta1.transform.localPosition = puerta1PosFin;
    //    timer();
    //}

    //void cerrarPuertas()
    //{
    //    puerta1.transform.localPosition = puerta1PosIn;
    //}

    void timer()
    {
        tiempo -= Time.deltaTime;
        if (tiempo <= 0)
        {
            isCollision = false;
            anim.SetBool("isPress", false);
            resetTimer();

        }
    }

    void resetTimer()
    {
        tiempo = 3;
    }
}
