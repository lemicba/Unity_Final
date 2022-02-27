using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthAndDamage : MonoBehaviour
{
    public int health = 3;
    public bool invincible = false;
    public float tiempo = 1f;
    public float timeStopped = 0.2f;
    public int lifePublic;

    public static HealthAndDamage instance;

    private Animator anim;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        lifePublic = health;
        if (health <= 0)
        {
            Debug.Log("entro a health");
            EventManager.TriggerGameOver();
            GameManager.instance.SetCurrentState(GameManager.gameState.GameOver);
        }
    }

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
            Life.heart.ReduceHeart();
            anim.Play("Damage");
            invincible = true;
            StartCoroutine(StopVelocity());
 
        }
    }
    public void AddLife(int amountLife)
    {
        health += amountLife;
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

    private void OnEnable()
    {
        EventManager.OnGameOver += OnGameOverHandler;
    }

    private void OnDisable()
    {
        EventManager.OnGameOver -= OnGameOverHandler;
    }

    private void OnGameOverHandler()
    {
        SceneManager.LoadScene("DieMenu");
    }

}
