using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //Atributo 
    public Animator animator;
    
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
        player = transform.position;
        up = transform.up;
        forward = transform.forward;

        resultado = player + up * p - forward * q;
        posCamara.position = resultado;

        //Controlar el giro de la camara
        camaraForward = player + up * alturaCamara - posCamara.position;
        //Creo la rotación 
        posCamara.rotation = Quaternion.LookRotation(camaraForward);


        //Al dejar de presionar tecla
        //Flecha Arriba
        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            animator.SetBool("isWalking", false);
        }
        //Flecha Abajo
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("isWalkingBackward", false);
        }
        //Flecha Izquierda
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("isTurnLeft", false);
        }
        //Flecha Derecha
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("isTurnRight", false);
        }
        //Shift para correo
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("isRunning", false);
        }
        //Spacebar para saltar
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("isJumping", false);
        }


        //Al presionar Tecla
        //Flecha Arriba
        if (Input.GetKey(KeyCode.UpArrow)) {
            animator.SetBool("isWalking", true);
        }
        //Flecha Abajo
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("isWalkingBackward", true);
        }
        //Flecha Izquierda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("isTurnLeft", true);
        }
        //Flecha Derecha
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("isTurnRight", true);
        }
        //Tecla shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isRunning", true);
        }
        //Tecla spacebar
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
        }
    }
}
