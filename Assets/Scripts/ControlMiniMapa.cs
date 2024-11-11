using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMiniMapa : MonoBehaviour
{

    public Transform mapaHorizontal;
    public Transform pinMapa;

    public float k;

    Vector3 mapaPosInicial;


// ------------------------------------------------------------------------------
    void Start()
    {

        mapaPosInicial = mapaHorizontal.localPosition;

    }
// ------------------------------------------------------------------------------
    public void MoverMapa() {

        //float k = 40;
        mapaHorizontal.localPosition = mapaPosInicial + new Vector3(k * pinMapa.localPosition.x, 0, k * pinMapa.localPosition.z);
        //pinMapa.localPosition


        //Debug.LogError(pinMapa.localPosition);

    }
// ------------------------------------------------------------------------------
    void Update()
    {

        MoverMapa();
        
    }
}
