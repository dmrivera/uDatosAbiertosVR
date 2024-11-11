using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Clase para elementos del ui que requieren ser orientados hacia la cámara, tener en cuenta que solo se orientan sobre su eje vertical*/
public class LookToCamera : MonoBehaviour
{
    [Header("Features settings")]
    public Transform cam;
    public bool look = false;
    public Vector3 theta;

    public void LookCamera(){

        Vector3 dif = cam.transform.position - transform.position;
        Quaternion angle = Quaternion.LookRotation(dif, Vector3.up);
        Vector3 s = new Vector3(0, angle.eulerAngles.y + theta.y, 0);
        transform.rotation = Quaternion.Euler(s);

    }

    void Update(){
        
        if(look)
            LookCamera();
    }
}
