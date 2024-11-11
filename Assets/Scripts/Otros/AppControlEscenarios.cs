using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AppControlEscenarios : MonoBehaviour
{

    public GameObject vrPlayer;
    public Texture[] imagen360;
    public GameObject esfera360;
    Transform ultimaPosicion;
    public GameObject mapasGigantes;

// ------------------------------------------------------------------------------
    void Start() {
      
        

    }
// ------------------------------------------------------------------------------
    public void CambiarImagen360(int indice) {

        vrPlayer.transform.position = esfera360.transform.position;
        esfera360.transform.GetChild(0).GetComponent<Renderer>().material.mainTexture = imagen360[indice];
        esfera360.transform.GetChild(0).gameObject.SetActive(true);

    }
// ------------------------------------------------------------------------------
    public void RegresarDesde360() {


        vrPlayer.transform.position = ultimaPosicion.position;
        esfera360.transform.GetChild(0).gameObject.SetActive(false);

    }
// ------------------------------------------------------------------------------
    public void Teletransportar(Transform posicion) {

        vrPlayer.transform.position = posicion.position;
        ultimaPosicion = posicion;


    }
// ------------------------------------------------------------------------------
    public void IrAMapasGigantes(int indiceMapa) {

        vrPlayer.transform.position = new Vector3(0,200,0);

        mapasGigantes.SetActive(true);
        mapasGigantes.transform.GetChild(indiceMapa).gameObject.SetActive(true);

    }
// ------------------------------------------------------------------------------
    public void RegresarDesdeMapaGigante()
    {


        vrPlayer.transform.position = ultimaPosicion.position;

        mapasGigantes.SetActive(false);
        mapasGigantes.transform.GetChild(0).gameObject.SetActive(false);
        mapasGigantes.transform.GetChild(1).gameObject.SetActive(false);

    }
}
