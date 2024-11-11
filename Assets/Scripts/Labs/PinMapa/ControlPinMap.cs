using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPinMap : MonoBehaviour {


public Transform mapaHorizontal;
public Transform pinMapa;
public Transform pin;
public Transform vrUsuario;

Vector3 posicionInicialVR;
Vector3 posicionInicialPinMapa;
float   escalaMapa = 40;


// -------------------------------------------------------------------------------
    void Start() {

        posicionInicialVR = mapaHorizontal.position;
        posicionInicialPinMapa = pinMapa.position;

    }
// -------------------------------------------------------------------------------
    public void ActualizarPosicion() {


        vrUsuario.position = posicionInicialVR + new Vector3(escalaMapa * pin.localPosition.x, 0, escalaMapa * pin.localPosition.z);
        pinMapa.position = posicionInicialPinMapa + new Vector3(escalaMapa* pin.localPosition.x, 0, escalaMapa* pin.localPosition.z);

}
// -------------------------------------------------------------------------------
    //void Update() {

    //    //ActualizarPosicion();


    //}
}
