using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //Atributo 
    public float altura = 2;
    public float distancia = 3;

    public Transform transCamara { get; set; }

    private void Update()
    {
        transCamara.position = transform.position + transform.up * altura - transform.forward * distancia;

        //Rotacion Camara 
        Vector3 camaraForward = transform.position + transform.up * altura - transCamara.position;
        transCamara.rotation = Quaternion.LookRotation(camaraForward);

        Ray rayPlayer = new Ray(transform.position, transform.forward);
        Debug.DrawRay(rayPlayer.origin, rayPlayer.direction, Color.red);

        Ray rayCamara = new Ray(transCamara.position, transCamara.forward);
        Debug.DrawRay(rayCamara.origin, rayCamara.direction, Color.blue);
    }
}
