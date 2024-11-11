using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppControlGeneral : MonoBehaviour {


    public Transform  mapaHorizontal;
    public Transform  pinMapa;

    Vector3 mapaPosInicial;

    [Header("Datos")]
    public GameObject[] contenedorDatos;
    public CargarDatosAbiertos datosAbiertos;


// ------------------------------------------------------------------------------
    void Awake() {

    }
// ------------------------------------------------------------------------------
    IEnumerator Start() {

        //mapaPosInicial = mapaHorizontal.localPosition;

        //yield return new WaitForSeconds(1);
        ////mesas.transform.GetChild(0).gameObject.SetActive(true);

        //yield return new WaitForSeconds(5);

        ////ministro.SetActive(true);
        

        yield return null;
    }
// ------------------------------------------------------------------------------
    public void BotonTablet(int indiceBoton) {

        //contenedorDatos[indiceBoton].SetActive(!contenedorDatos[indiceBoton].activeSelf);

        if (indiceBoton ==-1) {

            contenedorDatos[0].SetActive(false);
            contenedorDatos[1].SetActive(false);
            contenedorDatos[2].SetActive(false);
            contenedorDatos[3].SetActive(false);
            
        }
        else if(indiceBoton == 0) {
            contenedorDatos[indiceBoton].SetActive(true);
            //datosAbiertos.CargarDatosCMH_MasacresParticulas();
            datosAbiertos.CorrutinaAnimacion();

        }
        else if (indiceBoton == 1)
        {
            contenedorDatos[indiceBoton].SetActive(true);
            datosAbiertos.CargarDatosCMH_MinasParticulas();

        }
        else if (indiceBoton == 2)
        {
            contenedorDatos[indiceBoton].SetActive(true);
            datosAbiertos.CargarDatos_DA_DistritosParticulas();

        }
        



    }
// ------------------------------------------------------------------------------
    public void BotonOprimido(int indiceBoton) {


    }
// ------------------------------------------------------------------------------
    //public void MoverMapa() {

    //    float k = 40;
    //    mapaHorizontal.localPosition = mapaPosInicial + new Vector3(k*pinMapa.localPosition.x, 0, k*pinMapa.localPosition.z );

    //}
// ------------------------------------------------------------------------------
    void Update() {


    //activar por teclado
        if (Input.GetKeyDown("0")) {
            BotonTablet(-1);
        }
        else if (Input.GetKeyDown("1"))
        {
            BotonTablet(0);
        }
        else if (Input.GetKeyDown("2")) {
            BotonTablet(1);
        }
        else if (Input.GetKeyDown("3")) {
            BotonTablet(2);
        }
        else if (Input.GetKeyDown("4")) {
            BotonTablet(3);
        }
        else if (Input.GetKeyDown("5")) {
            BotonTablet(0);
        }


    }
}
