using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BehaviourAudioA : MonoBehaviour
{
    public LoadData loadData;
    AudioSource audioSource;

    void Awake(){

        loadData = FindObjectOfType<LoadData>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable() => StartCoroutine(StartAnimationA());

    public IEnumerator StartAnimationA(){

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
        StartCoroutine(StartAnimationA());
    }

    IEnumerator SetHogares(){

        foreach (GameObject hogar in loadData.hogaresList){

            hogar.GetComponent<prefabHogar>().state = true;
            yield return new WaitForSeconds(0.096f);
        }
    }

    IEnumerator SetZCP(){

        foreach (GameObject zcp in loadData.zcpList){

            zcp.GetComponent<prefabZCP>().state = true;
            yield return new WaitForSeconds(0.065573f);
        }

    }
    void DisableHogares(){

        foreach (GameObject hogar in loadData.hogaresList)
            hogar.GetComponent<prefabHogar>().state = false;
    }

    void DisableZCP(){

        foreach (GameObject zcp in loadData.zcpList)
            zcp.GetComponent<prefabZCP>().state = false;
    }

    void OnDisable(){

        DisableHogares();
        DisableZCP();

        audioSource.Stop();

    }

}
