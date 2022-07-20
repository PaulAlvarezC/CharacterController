using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //Atributo 
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
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
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("isTurnLeft", false);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("isTurnRight", false);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("isRunning", false);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("isJumping", false);
        }


        //Al presionar Tecla
        if (Input.GetKey(KeyCode.UpArrow)) {
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("isWalkingBackward", true);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("isTurnLeft", true);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("isTurnRight", true);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isRunning", true);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
        }
    }
}
