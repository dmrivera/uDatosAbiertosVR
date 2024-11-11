using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class prefabZCP : MonoBehaviour
{
    LoadData loadData;
    Transform baseT;
    Transform iconT;
    string zcpT;
    float n = 0;
    public bool state;

    void Start(){

        loadData = FindObjectOfType<LoadData>();

        iconT = transform.Find("icon");
        baseT = transform.Find("base");
    }

    public void SetFeatures(string zcp) => zcpT = zcp;

    void Update(){

        baseT.localScale = new Vector3 (loadData.radioZCP,loadData.Normalized(zcpT,loadData.maxZCP,loadData.powerZCP)*loadData.heightZCP,loadData.radioZCP);
        baseT.GetComponentInChildren<MeshRenderer>().material.color = loadData.colorZCP.Evaluate(loadData.Normalized(zcpT,loadData.maxZCP,loadData.powerZCP));

        
        iconT.localScale = new Vector3(loadData.radioZCP,1,loadData.radioZCP);
        iconT.localPosition = new Vector3(0,baseT.localScale.y*2,0);
        iconT.GetChild(0).Find("wifi").GetComponent<Image>().color = loadData.colorZCP.colorKeys[2].color;
        iconT.GetChild(0).Find("wifi").gameObject.SetActive(true);

        //    if(state){

        //            if(n < 1){
        //                n += .01f;
        //                transform.localScale = new Vector3(n,n,n);
        //            }
        //            else{
        //                n=1;
        //                transform.localScale = Vector3.one;
        //            }                    
        //    }
        //    else{

        //        if(n > 0){
        //                n -= .01f;
        //                transform.localScale = new Vector3(n,n,n);
        //            }
        //            else{
        //                n=0;
        //                transform.localScale = Vector3.zero;
        //            }
        //    }
    }
}
