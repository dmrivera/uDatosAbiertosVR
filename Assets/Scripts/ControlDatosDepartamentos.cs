using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlDatosDepartamentos : MonoBehaviour {

    public Transform contenedorCilindros;
    public TextAsset archivoDatos;

    TMP_Text title, value;
    Transform baseT;
    Transform dataT;

    string[,] data;

    [Header("Data")]
    public Gradient color34;

    [Range(.01f, 1f)] public float radioCilindro;
    [Range(.1f, 10f)] public float alturaCilindro;
    [Range(.2f,  5f)] public float potencia;


// -------------------------------------------------------------------------------
    void Awake() {

        //cargar datos
        ObtenerDatosDepartamentos(archivoDatos);

        ActualizarDatos(3);

        //Debug.LogWarning(data[6, 3]);

    }
// -------------------------------------------------------------------------------
    void GetAditionalHeight() {

        RaycastHit hit;

        if (Physics.Raycast(new Vector3(transform.position.x, 2, transform.position.z), transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);

    }
// -------------------------------------------------------------------------------
    void ObtenerDatosDepartamentos(TextAsset datafile) {

            string s = datafile.text;
            string[] rows = s.Split('\n');

            data = new string[rows.Length, rows[0].Split('\t').Length];

            for (int n = 0; n < rows.Length; n++) {

                string[] columns = (rows[n].Trim()).Split('\t');

                for (int m = 0; m < columns.Length; m++) {
                    data[n, m] = columns[m];
                }
            }

    }
// -------------------------------------------------------------------------------
    void ActualizarDatos(int indiceDato) {

        for (int n = 0; n < contenedorCilindros.childCount; n++) {

            //contenedorCilindros.GetChildCount(n)
            dataT = contenedorCilindros.GetChild(n).transform.Find("data");
            baseT = contenedorCilindros.GetChild(n).transform.Find("base");

            title = dataT.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>();
            value = dataT.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<TMP_Text>();


            baseT.localScale = new Vector3( radioCilindro, 
                                            Normalized(data[n + 1, indiceDato], GetMaxValue(data, indiceDato), potencia) * alturaCilindro, 
                                            radioCilindro);
            baseT.GetComponentInChildren<MeshRenderer>().material.color = color34.Evaluate(Normalized(data[n + 1, indiceDato], GetMaxValue(data, indiceDato), potencia));

            dataT.localScale = new Vector3(1, 1, baseT.localScale.x);
            dataT.localPosition = new Vector3(0, baseT.localScale.y * 2, 0);

            //title.text = data[n+1, 0];
            value.text = data[n+1, indiceDato];

            //ocular si el dato es 0
            //dataT.gameObject.SetActive(float.Parse(data[n, 2]) > 0);
            //baseT.gameObject.SetActive(float.Parse(data[n, 2]) > 0);
            //title.color = color34.colorKeys[2].color;
            //value.color = color34.colorKeys[2].color;

        }

    }
// -------------------------------------------------------------------------------
    public float Normalized(string s, float max, float pow)
    {

        float v = float.Parse(s);
        float vN = v / max;
        vN = MathF.Pow(vN, pow);
        return vN;
    }
// -------------------------------------------------------------------------------
    float GetMaxValue(string[,] s, int c)
    {

        float max = 0;
        float val = 0;

        for (int n = 1; n < s.GetLength(0); n++) {
            if (string.IsNullOrEmpty(s[n, c]))
                break;
            val = float.Parse(s[n, c]);
            max = val > max ? val : max;
        }

        return max;
    }
// -------------------------------------------------------------------------------
    void Update() {


        //ActualizarDatos(3);


    }
}
