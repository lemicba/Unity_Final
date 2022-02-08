using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventary : MonoBehaviour
{
    public bool destroyWithCursor;
    public bool destroyAutomatic;
    public PlayerController playerController;

    public int tipe;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void Efecto()
    {
        switch (tipe)
        {
            case 1:
                playerController.gameObject.transform.localScale = new Vector3(3, 3, 3);
                break;
            case 2:
                playerController.velocidadDeMovimiento += 5;
                break;
            case 3:
                playerController.alturaDelSalto += 10;
                break;
            default:
                Debug.Log("sin efecto");
                break;
        }
    }
}
