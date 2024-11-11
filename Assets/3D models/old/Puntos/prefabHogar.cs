using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class prefabHogar : MonoBehaviour
{
    LoadData loadData;
    Transform baseT;
    Transform iconT;
    string hogaresT;
    float n = 0;
    public bool state;

    void Start(){

        loadData = FindObjectOfType<LoadData>();

        iconT = transform.Find("icon");
        baseT = transform.Find("base");

        state = false;
    }

    public void SetFeatures(string hogares) => hogaresT = hogares;

    void Update(){

        baseT.localScale = new Vector3 (loadData.radioH,loadData.Normalized(hogaresT,loadData.maxHogares,loadData.powerH)*loadData.heightH,loadData.radioH);
        baseT.GetComponentInChildren<MeshRenderer>().material.color = loadData.colorHogares.Evaluate(loadData.Normalized(hogaresT,loadData.maxHogares,loadData.powerH));
        
        iconT.localScale = new Vector3(loadData.radioH,1,loadData.radioH);
        iconT.localPosition = new Vector3(0,baseT.localScale.y*2,0);
        iconT.GetChild(0).Find("house").GetComponent<Image>().color = loadData.colorHogares.colorKeys[2].color;
        iconT.GetChild(0).Find("house").gameObject.SetActive(true);

        //if(state){

        //        if(n < 1){
        //            n += .01f;
        //            transform.localScale = new Vector3(n,n,n);
        //        }
        //        else{
        //            n=1;
        //            transform.localScale = Vector3.one;
        //        }                    
        //}
        //else{

        //    if(n > 0){
        //            n -= .01f;
        //            transform.localScale = new Vector3(n,n,n);
        //        }
        //        else{
        //            n=0;
        //            transform.localScale = Vector3.zero;
        //        }
        //}
    }
}
