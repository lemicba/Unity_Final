using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controlador;
    public Transform camara;
    public float velocidadDeMovimiento;
    private float rotacionSuave = 0.1f;
    float velocidadRotacionSuave;
    public float gravedad = -9.81f;
    public float alturaDelSalto;
    public Animator anim;
    public bool running;

    public Transform chequeadorDeSuelo;
    public Transform originRay;
    public float distanciaAlSuelo;
    public LayerMask mascaraDeSuelo;
    bool estaEnElSuelo;

    Vector3 velocidad;
    public static PlayerController player = null;
    private void Awake()
    {
        if(player == null)
        {
            player = this;
        } else if ( player != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {

        estaEnElSuelo = Physics.CheckSphere(chequeadorDeSuelo.position, distanciaAlSuelo, mascaraDeSuelo);
        if (estaEnElSuelo && velocidad.y < 0)
        {
            velocidad.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direccion = new Vector3(horizontal, 0f, vertical).normalized;

        if (direccion.magnitude >= 0.1f)
        {
            float anguloARotar = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + camara.eulerAngles.y;
            float angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloARotar, ref velocidadRotacionSuave, rotacionSuave);
            transform.rotation = Quaternion.Euler(0f, angulo, 0f);

            Vector3 direccionDelMovimiento = Quaternion.Euler(0f, anguloARotar, 0f) * Vector3.forward;
            anim.SetBool("running", true);
            controlador.Move(direccionDelMovimiento.normalized * velocidadDeMovimiento * Time.deltaTime);
        }
        else {
            anim.SetBool("running", false);
        }

        if (Input.GetButtonDown("Jump") && estaEnElSuelo)
        {
            velocidad.y = Mathf.Sqrt(alturaDelSalto * -2f * gravedad);
        }

        velocidad.y += gravedad * Time.deltaTime;
        controlador.Move(velocidad * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Vector3 originRay = transform.position + new Vector3(0.0f, 1.0f);
        RaycastHit hit;

        if (Physics.Raycast(originRay, transform.TransformDirection(Vector3.forward), out hit, 5.0f))
        {
            Debug.DrawRay(originRay, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            if(hit.collider.gameObject.tag == "IA" && hit.distance < 5)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<EnemyOne>().pressBtn = true;
                }else
                {
                    hit.collider.gameObject.GetComponent<EnemyOne>().pressBtn = false;
                }
            }
        }
        else
        {
            Debug.DrawRay(originRay, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
        }
    }

}