using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform Objetivo;
    public float distanciaMinima = 2f;
    //public enum Enemy { Enemigo1, Enemigo2 };

    //public Enemy ActiveState = Enemy.Enemigo1;
    public float Veloc = 2f;

    void Update()
    {                
        Vector3 vectorObjetivo = ObtenerObjetivo();

        if (Moverse(vectorObjetivo))
        {
            Perseguir(vectorObjetivo);
        }
    }

    private Vector3 ObtenerObjetivo()
    {
        Vector3 direccion = Objetivo.position - transform.position;
        direccion.y = 0;

        return direccion;
    }
    private void Perseguir(Vector3 vectorObj)
    {
        transform.Translate(vectorObj.normalized * Veloc * Time.deltaTime, Space.World);
    }

    private bool Moverse(Vector3 vectorObj)
    {
        return vectorObj.magnitude > distanciaMinima;
    }
}
