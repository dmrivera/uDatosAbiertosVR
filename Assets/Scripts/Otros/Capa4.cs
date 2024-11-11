using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capa4 : MonoBehaviour
{

public GameObject appControl;
public GameObject dioramas;
public GameObject departamentos;
public GameObject circulos;
public GameObject vice1;
public Transform  mesas;


    //-------------------------------------------------------------
    IEnumerator Start() {

        for (int i = 0; i < dioramas.transform.childCount; i++) {
            dioramas.transform.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < departamentos.transform.childCount; i++) {
            departamentos.transform.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < circulos.transform.childCount; i++) {
            circulos.transform.GetChild(i).gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(3);
        IniciarCapa2();


        yield return null;
    }
//-------------------------------------------------------------
    public void IniciarCapa2() {

        StartCoroutine(CorrutinaCapa2());
        
    }
//-------------------------------------------------------------
    IEnumerator CorrutinaCapa2() {

        yield return new WaitForSeconds(1);
        //iniciar audio
        vice1.GetComponent<AudioSource>().Play();

mesas.GetChild(3).gameObject.SetActive(true);

        //12 guajira 
        yield return new WaitForSeconds(13);
        departamentos.transform.GetChild(0).gameObject.SetActive(true);
        //14 amaz
        yield return new WaitForSeconds(1);
        departamentos.transform.GetChild(1).gameObject.SetActive(true);
        //15 vichada
        yield return new WaitForSeconds(1);
        departamentos.transform.GetChild(2).gameObject.SetActive(true);
        //16 nariño
        yield return new WaitForSeconds(1);
        departamentos.transform.GetChild(3).gameObject.SetActive(true);
        //17 cauca
        yield return new WaitForSeconds(1);
        departamentos.transform.GetChild(4).gameObject.SetActive(true);
        //17 valle
        yield return new WaitForSeconds(1);
        departamentos.transform.GetChild(5).gameObject.SetActive(true);
        //19 choco
        yield return new WaitForSeconds(1);
        departamentos.transform.GetChild(6).gameObject.SetActive(true);

        yield return new WaitForSeconds(8);

        //dioramas
        for (int i = 0; i < dioramas.transform.childCount; i++) {
            dioramas.transform.GetChild(i).gameObject.SetActive(true);
            circulos.transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(10);
        mesas.GetChild(3).gameObject.SetActive(true);


        yield return null;

    }

}
