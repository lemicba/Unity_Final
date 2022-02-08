using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    public Transform Objetivo;
    public float velocidadGiro = 2f;
    void Start()
    {

    }
    void Update()
    {
        Vector3 direccionObjetivo = TomarDireccion();
        Girar(direccionObjetivo);
    }

    private Vector3 TomarDireccion()
    {
        Vector3 direccion = Objetivo.position - this.transform.position;
        direccion.y = 0;
        return direccion;
    }
    private void Girar( Vector3 direccion)
    {
        if(direccion != Vector3.zero)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotacionObjetivo, velocidadGiro * Time.deltaTime);
        }
    }
}
