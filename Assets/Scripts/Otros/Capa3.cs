using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capa3 : MonoBehaviour
{

//public GameObject appControl;
//public GameObject dioramas;
//public GameObject departamentos;
//public GameObject circulos;
//public GameObject vice1;
public Transform  mesas;


    //-------------------------------------------------------------
    IEnumerator Start() {

        //for (int i = 0; i < dioramas.transform.childCount; i++) {
        //    dioramas.transform.GetChild(i).gameObject.SetActive(false);
        //}
        //for (int i = 0; i < departamentos.transform.childCount; i++) {
        //    departamentos.transform.GetChild(i).gameObject.SetActive(false);
        //}
        //for (int i = 0; i < circulos.transform.childCount; i++) {
        //    circulos.transform.GetChild(i).gameObject.SetActive(false);
        //}

        yield return new WaitForSeconds(88);

        mesas.transform.GetChild(4).gameObject.SetActive(true);
        //IniciarCapa3();


        yield return null;
    }
//-------------------------------------------------------------
    public void IniciarCapa3() {

        StartCoroutine(CorrutinaCapa3());
        
    }
//-------------------------------------------------------------
    IEnumerator CorrutinaCapa3() {


        yield return null;

    }

}
