using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class prefabData34 : MonoBehaviour
{
    LoadData loadData;
    Transform baseT;
    Transform dataT;
    public string[] dataV;
    float n = 0;
    public bool state;
    public TMP_Text title,value;

    int nAnterior = -1;

    void Start(){

        loadData = FindObjectOfType<LoadData>();

        dataT = transform.Find("data");
        baseT = transform.Find("base");

//GetComponent<LookToCamera>().cam = loadData.cam;
        state = false;
        GetAditionalHeight();

    }

    public void SetFeatures(string[] datos) => dataV = datos;

    void Update(){

        if(nAnterior== loadData.infoN) {
            return;
        }
        nAnterior = loadData.infoN;
        gameObject.GetComponent<Animator>().Play("BotonAparece");

        baseT.localScale = new Vector3 (loadData.radio34,loadData.Normalized(dataV[loadData.infoN],loadData.maxData34[loadData.infoN],loadData.power34)*loadData.height34,loadData.radio34);
        baseT.GetComponentInChildren<MeshRenderer>().material.color = loadData.color34.Evaluate(loadData.Normalized(dataV[loadData.infoN],loadData.maxData34[loadData.infoN],loadData.power34));
        
        dataT.localScale = new Vector3(1,1,baseT.localScale.x);
        dataT.localPosition = new Vector3(0,baseT.localScale.y*2,0);

        title.text = gameObject.name;
        value.text = dataV[loadData.infoN];

        dataT.gameObject.SetActive(float.Parse(dataV[loadData.infoN]) > 0);
        baseT.gameObject.SetActive(float.Parse(dataV[loadData.infoN]) > 0);

        title.color = loadData.color34.colorKeys[2].color;
        value.color = loadData.color34.colorKeys[2].color;    

        title.transform.parent.gameObject.SetActive(loadData.infoA);
        value.transform.parent.gameObject.SetActive(loadData.infoB);

        /* if(state){

                if(n < 1){
                    n += .01f;
                    transform.localScale = new Vector3(n,n,n);
                }
                else{
                    n=1;
                    transform.localScale = Vector3.one;
                }                    
        }
        else{

            if(n > 0){
                    n -= .01f;
                    transform.localScale = new Vector3(n,n,n);
                }
                else{
                    n=0;
                    transform.localScale = Vector3.zero;
                }
        } */
    }
    void GetAditionalHeight() {

        RaycastHit hit;

        if (Physics.Raycast(new Vector3(transform.position.x, 2, transform.position.z), transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);

    }
}
