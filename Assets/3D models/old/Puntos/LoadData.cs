using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class LoadData : MonoBehaviour
{
    [Header("General")]
    public Transform cam;
    public List<TextAsset> datafiles;
    
    [Header("ZCP")]
    public Gradient colorZCP;
    public GameObject zcp_prefab;
    public Transform refA,refB;
    public Transform zcp_parent;
    [Range(.01f,2f)] public float radioZCP;
    [Range(.0f,5f)] public float heightZCP;
    [Range(.1f,5f)] public float powerZCP;
    string[,] ZCPdata;
    [HideInInspector] public float maxZCP;
    [HideInInspector] public List<GameObject> zcpList = new List<GameObject>();


    [Header("Hogares Interconectados")]
    public Gradient colorHogares;
    public GameObject hogares_prefab;
    public Transform refC,refD;
    public Transform hogares_parent;
    [Range(.01f,2f)] public float radioH;
    [Range(.0f,5f)] public float heightH;
    [Range(.1f,5f)] public float powerH;
    string[,] Hogaresdata;
    [HideInInspector] public float maxHogares;
    [HideInInspector] public List<GameObject> hogaresList = new List<GameObject>();

    [Header("Data 3 - 4")]
    public Gradient color34;
    public GameObject data34_prefab;
    public Transform refE,refF;
    public Transform data34_parent;
    [Range(.01f,1f)] public float radio34;
    [Range(.1f,10f)] public float height34;
    [Range(.2f,5f)] public float power34;

    string[,] data34;
    [HideInInspector] public float[] maxData34;
    [HideInInspector] public List<GameObject> data34List = new List<GameObject>();


    [Range(0,11)] [Tooltip("Determina el indice de la columna de datos activa")] public int infoN = 0;
    public bool infoA,infoB;


// ------------------------------------------------------------------------------
    void Start(){

        ZCPdata = LoadAllData(datafiles[0]);
        Hogaresdata = LoadAllData(datafiles[1]);    
        data34 = LoadAllData(datafiles[2]);
        
        //LoadZCP();
        //LoadHogares();
        //LoadData34();
    }
// ------------------------------------------------------------------------------
    public void ActualizarN( int n) {

        infoN = n;

    }
// ------------------------------------------------------------------------------
    string[,] LoadAllData(TextAsset datafile){
        
        string s = datafile.text;
        string[] rows = s.Split('\n');

        string[,] data = new string[rows.Length,rows[0].Split('\t').Length];

        for (int n = 0; n < rows.Length; n++){

            string[] columns = (rows[n].Trim()).Split('\t');

            for (int m = 0; m < columns.Length; m++){
                //print($"[{n},{m}]{columns[m]}");
                data[n,m] = columns[m];
            }
        }     

        return data;
        
    }
    void LoadZCP(){

        string name = "", lat = "", longt = "", zcp = "";
        float latF, longtF;
        maxZCP = GetMaxValue(ZCPdata,1);

        float[] mat = GetSpatialReferences(refA,refB,ZCPdata[26,2],ZCPdata[26,3],ZCPdata[174,2],ZCPdata[174,3],true);

        for (int n = 1; n < ZCPdata.GetLength(0); n++){

            if(string.IsNullOrEmpty(ZCPdata[n,0]))
                break;

            zcp = ZCPdata[n, 1];
            lat = ZCPdata[n, 2];
            longt = ZCPdata[n, 3];
            name = ZCPdata[n, 4];

            /* lat = lat.Replace('.', ',');
            longt = longt.Replace('.', ','); */

            latF = float.Parse(lat);
            longtF = float.Parse(longt);

            Vector3 posN = GetNewData(latF, longtF,mat);
            GameObject point = Instantiate(zcp_prefab, new Vector3(posN.x,posN.z,3.3f), Quaternion.identity,zcp_parent);
            point.transform.localRotation = Quaternion.Euler(-90,0,0);
            point.AddComponent<prefabZCP>().SetFeatures(zcp);
            point.name = name;
            point.gameObject.SetActive(false);
            zcpList.Add(point);
        }
    }
    void LoadHogares(){

        string name = "", lat = "", longt = "", hog = "";
        float latF, longtF;
        maxHogares = GetMaxValue(Hogaresdata,4);
        //print(max);

        float[] mat = GetSpatialReferences(refC,refD,Hogaresdata[173,5],Hogaresdata[173,6],Hogaresdata[176,5],Hogaresdata[176,6],true);

        for (int n = 1; n < Hogaresdata.GetLength(0); n++){

            if(string.IsNullOrEmpty(Hogaresdata[n,0]))
                break;

            name = Hogaresdata[n, 2];    
            hog = Hogaresdata[n, 4];
            lat = Hogaresdata[n, 5];
            longt = Hogaresdata[n, 6];



            //lat = lat.Replace('.', ',');
            //longt = longt.Replace('.', ',');

            latF = float.Parse(lat);
            longtF = float.Parse(longt);



            Vector3 posN = GetNewData(latF, longtF,mat);
            GameObject point = Instantiate(hogares_prefab, new Vector3(posN.x,posN.z,3.3f), Quaternion.identity,hogares_parent);
            point.transform.localRotation = Quaternion.Euler(-90,0,0);
            point.AddComponent<prefabHogar>().SetFeatures(hog);
            point.name = name;
            point.gameObject.SetActive(false);
            hogaresList.Add(point);
        }
    }
    void LoadData34(){

        string name = "", lat = "", longt = "";
        float latF, longtF;
        maxData34 = new float[12];

        for (int i = 0; i < maxData34.Length; i++)
            maxData34[i] = GetMaxValue(data34,i+1);

        float[] mat = GetSpatialReferences(refE,refF,data34[4,13],data34[4,14],data34[1,13],data34[1,14],false);

        for (int n = 1; n < data34.GetLength(0); n++){

            if(string.IsNullOrEmpty(data34[n,0]))
                break;

            string[] dataV = new string[12];

            name = data34[n, 0];

            for (int i = 1; i < data34.GetLength(1)-2; i++){
                //print(name +"="+ data34[n,i]);
                dataV[i-1] = data34[n,i];
            }

            lat = data34[n, 13];
            longt = data34[n, 14];

            /* lat = lat.Replace('.', ',');
            longt = longt.Replace('.', ','); */

            latF = float.Parse(lat);
            longtF = float.Parse(longt);



            GameObject point = Instantiate(data34_prefab, GetNewData(latF, longtF,mat), Quaternion.identity,data34_parent);
            point.GetComponent<prefabData34>().SetFeatures(dataV);
            point.name = name;
            //point.gameObject.SetActive(false);
            data34List.Add(point);
        }


    }

    #region Mathematical Methods
    float[] GetSpatialReferences(Transform refLocalA,Transform refLocalB,string A1,string A2,string B1,string B2,bool vertical){

        float Mx, Bx, My, By;

        Vector2 refRealA = new Vector2(float.Parse(A1), float.Parse(A2));
        Vector2 refRealB = new Vector2(float.Parse(B1), float.Parse(B2));

        if(vertical){

            Mx = (refLocalB.position.x - refLocalA.position.x) / (refRealB.x - refRealA.x);
            Bx = refLocalB.position.x - Mx * refRealB.x;

            My = (refLocalB.position.y - refLocalA.position.y) / (refRealB.y - refRealA.y);
            By = refLocalB.position.y - My * refRealB.y;

        }
        else{

            Mx = (refLocalB.position.x - refLocalA.position.x) / (refRealB.x - refRealA.x);
            Bx = refLocalB.position.x - Mx * refRealB.x;

            My = (refLocalB.position.z - refLocalA.position.z) / (refRealB.y - refRealA.y);
            By = refLocalB.position.z - My * refRealB.y;

        }

        float[] mat = new float[4];
        mat[0] = Mx;
        mat[1] = Bx;
        mat[2] = My;
        mat[3] = By;

        return mat;

    }
    Vector3 GetNewData(float lat,float longt,float[] mat){

        float newLat = mat[0] * lat + mat[1];
        float newLong = mat[2] * longt + mat[3];

        Vector3 newPos = new Vector3(newLat,0, newLong);

        return newPos;
    }
    public float Normalized(string s,float max,float pow){

        float v = float.Parse(s);
        float vN = v/max;
        vN = MathF.Pow(vN,pow);
        return vN;
    }
    float GetMaxValue(string[,] s,int c){
        
        float max = 0;
        float val = 0;

         for (int n = 1; n < s.GetLength(0); n++){

            if(string.IsNullOrEmpty(s[n,c]))
                break;

            val = float.Parse(s[n,c]);

            max = val > max ? val : max;
        }

        return max;

    }

    #endregion Mathematical Methods
}
