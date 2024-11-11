using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Clase para elementos del ui que requieren ser orientados hacia la cámara, 
 * tener en cuenta que solo se orientan sobre su eje vertical*/

public class RotateToCamera : MonoBehaviour
{
    
    public Transform objetivo;  // El objetivo al que quieres apuntar.


    void Update(){

        if (objetivo != null) {
            // Calcula la dirección hacia el objetivo solo en el eje Y.
            Vector3 direccionAlObjetivo = objetivo.position - transform.position;
            direccionAlObjetivo.y = 0;  // Mantén la dirección solo en el eje Y.

            // Calcula la rotación para apuntar al objetivo en el eje Y.
            Quaternion rotacionHaciaObjetivo = Quaternion.LookRotation(direccionAlObjetivo);

            // Aplica la rotación al objeto solo en el eje Y.
            transform.rotation = Quaternion.Euler(0, rotacionHaciaObjetivo.eulerAngles.y+90, 0);
        }
    }
}
