using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventManager : MonoBehaviour
{
    public int typeEv;
    public UnityEvent onCharacterScale;
    public UnityEvent onCharacterVelocity;
    public UnityEvent onCharacterJump;
    public PlayerController playerControllers;
    private void Start()
    {
        playerControllers = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        onCharacterScale.AddListener(onCharacterScaleHandler);
        onCharacterVelocity.AddListener(onCharacterVelocityHandler);
        onCharacterJump.AddListener(onCharacterJumpHandler);
    }

    public void onCharacterScaleHandler()
    {
        playerControllers.gameObject.transform.localScale = new Vector3(3, 3, 3);
    }

    public void onCharacterVelocityHandler()
    {
        playerControllers.velocidadDeMovimiento = 20;
    }

    public void onCharacterJumpHandler()
    {
        playerControllers.alturaDelSalto = 10;
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            switch (typeEv)
            {
                case 1:
                    onCharacterScale.Invoke();
                    break;
                case 2:
                    onCharacterVelocity.Invoke();
                    break;
                case 3:
                    onCharacterJump.Invoke();
                    break;
                default:
                    break;
            }

        }
    }
}