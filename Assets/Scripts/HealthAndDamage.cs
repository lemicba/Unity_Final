using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
<<<<<<< HEAD
    public int health = 3;
    public bool invincible = false;
    public float tiempo = 1f;
    public float timeStopped = 0.2f;
    public int lifePublic;
=======
    public int health = 100;
    public bool invincible = false;
    public float tiempo = 1f;
    public float timeStopped = 0.2f;
>>>>>>> main

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

<<<<<<< HEAD
    private void Update()
    {
        lifePublic = health;
        if (health <= 0)
        {
            GameManager.instance.SetCurrentState(GameManager.gameState.GameOver);
        }
    }

=======
>>>>>>> main

    public void SubtractLife(int amountDamage)
    {
        tiempo -= Time.deltaTime;
        if (tiempo <= 0)
        {
            invincible = false;
            resetTimer();
        }
        if (!invincible && health > 0 && tiempo != 0)
        {
            health -= amountDamage;
<<<<<<< HEAD
            Life.heart.ReduceHeart();
=======
>>>>>>> main
            anim.Play("Damage");
            invincible = true;
            StartCoroutine(StopVelocity());
 
        }
    }

    IEnumerator StopVelocity()
    {
        var velocidadActual = GetComponent<PlayerController>().velocidadDeMovimiento;
        GetComponent<PlayerController>().velocidadDeMovimiento = 0;
        yield return new WaitForSeconds(timeStopped);
        GetComponent<PlayerController>().velocidadDeMovimiento = velocidadActual;
    }

    void resetTimer()
    {
        tiempo = 1f;
    }

}
