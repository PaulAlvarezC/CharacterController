using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //Atributo 
    public Animator animator;
    public float speed = 2.0f;
    public float runningSpeed = 4.0f;
    public float rotationSpeed = 100.0f;

    //Vectores de direccion
    public Vector3 forward;
    public Vector3 up;
    public Vector3 player;

    public Vector3 resultado;

    public float p = 1.0f;  //Altura
    public float q = 1.0f;  //Distancia

    //Posicion de la camara
    public Transform posCamara;

    //Altura de Cámara
    public float alturaCamara = 0.5f;

    //Vector de giro
    public Vector3 camaraForward;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        player = transform.position;
        up = transform.up;
        forward = transform.forward;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float translationRunning = Input.GetAxis("Vertical") * runningSpeed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        translationRunning *= Time.deltaTime;
        rotation *= Time.deltaTime;

        player = transform.position;
        up = transform.up;
        forward = transform.forward;

        resultado = player + up * p - forward * q;
        posCamara.position = resultado;

        //Controlar el giro de la camara
        camaraForward = player + up * alturaCamara - posCamara.position;
        //Creo la rotación 
        posCamara.rotation = Quaternion.LookRotation(camaraForward);

        Ray rayPlayer = new Ray(transform.position, transform.forward);
        Debug.DrawRay(rayPlayer.origin, rayPlayer.direction, Color.red);

        Ray rayCamara = new Ray(posCamara.position, posCamara.forward);
        Debug.DrawRay(rayCamara.origin, rayCamara.direction, Color.blue);


        //Al dejar de presionar tecla
        //Flecha Arriba
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.Space)
            || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.F)) {
            animator.SetBool("isWalking", false);
            animator.SetBool("isWalkingBackward", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", false);
            animator.SetBool("isSalute", false);
        }

        //Al presionar Tecla
        //Flecha Arriba y Abajo
        if (Input.GetKey(KeyCode.UpArrow)) {
            animator.SetBool("isWalking", true);
            transform.Translate(0,0, translation);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("isWalkingBackward", true);
            transform.Translate(0, 0, translation);
        }
        //Flecha Izquierda y Derecha
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("isWalking", true);
            transform.Rotate(0, rotation, 0);
        }


        //Tecla shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isRunning", true);
            transform.Translate(0, 0, translationRunning);
        }
        //Tecla spacebar
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
        }
        //Tecla F
        if (Input.GetKey(KeyCode.F))
        {
            animator.SetBool("isSalute", true);
        }
    }
}
