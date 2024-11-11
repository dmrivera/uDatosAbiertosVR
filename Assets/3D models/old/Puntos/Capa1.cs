using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Capa1 : MonoBehaviour
{
    public LoadData loadData;

    public GameObject hogares;
    public GameObject zcp;

    AudioSource audioSource;

    public GameObject mesas;

    // ------------------------------------------------------------------------------
    void Awake(){

        loadData = FindObjectOfType<LoadData>();
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(StartAnimationA());
        

    }
    // ------------------------------------------------------------------------------
    //void OnEnable() => StartCoroutine(StartAnimationA());

    public IEnumerator StartAnimationA(){

        //yield return new WaitForSeconds(2);

//mesas.transform.GetChild(2).gameObject.SetActive(true);

        audioSource.Play();
        yield return new WaitForSeconds(6);

        StartCoroutine(SetHogares());
        yield return new WaitForSeconds(17);

        audioSource.Pause();
        yield return new WaitForSeconds(2f);
        DisableHogares();

        audioSource.Play();

        StartCoroutine(SetZCP());
        yield return new WaitForSeconds(12);

        yield return new WaitForSeconds(2);
        DisableZCP();
        //StartCoroutine(StartAnimationA());
        mesas.transform.GetChild(2).gameObject.SetActive(true);

    }
    // ------------------------------------------------------------------------------
    IEnumerator SetHogares(){

        //foreach (GameObject hogar in loadData.hogaresList) {

        //    hogar.SetActive(true);
        //    //hogar.GetComponent<prefabHogar>().state = true;
        //    Debug.LogWarning("1");
        //    //yield return new WaitForSeconds(0.096f);
        //    yield return new WaitForEndOfFrame();
        //    yield return new WaitForEndOfFrame();
        //}

        for (int i = 0; i < hogares.transform.childCount; i++) {

            hogares.transform.GetChild(i).gameObject.SetActive(true);

            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
        }

    }
// ------------------------------------------------------------------------------
    IEnumerator SetZCP(){
        //
        //foreach (GameObject zcp in loadData.zcpList){
        //    zcp.SetActive(true);
        //    //zcp.GetComponent<prefabZCP>().state = true;
        //    //yield return new WaitForSeconds(0.065573f);
        //    yield return new WaitForEndOfFrame();
        //    yield return new WaitForEndOfFrame();
        //}

        // no leer del fichero
        for (int i = 0; i < zcp.transform.childCount; i++) {

            zcp.transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
        }


    }
// ------------------------------------------------------------------------------
    void DisableHogares(){

        //foreach (GameObject hogar in loadData.hogaresList) {
        //    //hogar.GetComponent<prefabHogar>().state = false;
        //    hogar.GetComponent<Animator>().Play("BotonDesaparece");
        //}
        for (int i = 0; i < hogares.transform.childCount; i++) {

            hogares.transform.GetChild(i).GetComponent<Animator>().Play("BotonDesaparece"); ;

        }

    }
    // ------------------------------------------------------------------------------
    void DisableZCP(){

        //foreach (GameObject zcp in loadData.zcpList) {
        //    zcp.GetComponent<Animator>().Play("BotonDesaparece");
        //}
        //zcp.GetComponent<prefabZCP>().state = false;
        for (int i = 0; i < zcp.transform.childCount; i++) {

            zcp.transform.GetChild(i).GetComponent<Animator>().Play("BotonDesaparece"); ;

        }

    }
    // ------------------------------------------------------------------------------
    void OnDisable(){

        DisableHogares();
        DisableZCP();

        audioSource.Stop();

    }

}
