using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public Animator anim;
    public bool isPress;
    public float tiempo = 3;

    private bool isCollision = false;

    void Update()
    {
        if (isCollision)
        {
            anim.SetBool("isPress", true);
            timer();
        }
        if (!isCollision)
        {
            anim.SetBool("isPress", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollision = true;
        }
    }

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
