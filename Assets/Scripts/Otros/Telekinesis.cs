using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telekinesis : MonoBehaviour {


public Transform centroOjos;
Vector3 posInicial;

private float callTime = 0f;
private float delay = 2f;


// ------------------------------------------------------------------------------
    void Start() {

        posInicial = transform.position;

    }
//-------------------------------------------------------------
    public void MoverObjetoHaciaCamara(Vector3 posFinal) {

        transform.position = Vector3.Lerp(transform.position, posFinal, 0.05f);

    }
//-------------------------------------------------------------
    void Update() {

        Vector3 ObjetoA = centroOjos.position + new Vector3(0, 0.0f, 0);
        Transform ObjetoB = transform;//dioramas.transform.GetChild(0);

        // Lanzamos un rayo desde ObjetoA hacia ObjetoB
        Vector3 direccion = ObjetoB.position - ObjetoA;

        Vector3 desfase = ObjetoA + 0.2f * direccion.normalized;
        Vector3 desfasePosFinal = ObjetoA + 0.8f * direccion.normalized;

        
        Ray rayo = new Ray(desfase, direccion.normalized);
        //Ray rayo = new Ray(ObjetoA.position, direccion.normalized);

        // Comprobamos si hay colisiones con objetos en la capa de colisión
        RaycastHit hitInfo;
        if (Physics.Raycast(rayo, out hitInfo, direccion.magnitude)) {
            // Si hay una colisión, significa que hay un objeto entre ObjetoA y ObjetoB
            //Debug.Log("Hay un objeto entre ObjetoA y ObjetoB: " + hitInfo.collider.gameObject.name); //hitInfo.collider.gameObject.name
            MoverObjetoHaciaCamara(desfasePosFinal);
            callTime = Time.time;

        }
        else {
            // Si no hay colisión, no hay objetos entre ObjetoA y ObjetoB
            //Debug.Log("No hay objetos entre ObjetoA y ObjetoB.");
            //vice1.transform.position = posInicial;
            if (Time.time - callTime >= delay) {
                MoverObjetoHaciaCamara(posInicial);
            }
            

        }


    }
}
