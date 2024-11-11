using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltarEscena : MonoBehaviour
{

    public Transform capas;
    public GameObject mesas;

    // Start is called before the first frame update
    void Saltar(int indice)
    {
        for (int i = 0; i < capas.transform.childCount; i++) {
            capas.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < mesas.transform.childCount; i++) {
            mesas.transform.GetChild(i).gameObject.SetActive(false);
        }

        capas.GetChild(indice).gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")) {
            Debug.Log("techal");
            Saltar(1);
        }
        else if (Input.GetKeyDown("2")) {
            Debug.Log("techa2");
            Saltar(2);
        }
        else if (Input.GetKeyDown("3")) {
            Debug.Log("techa2");
            Saltar(3);
        }
        else if (Input.GetKeyDown("4")) {
            Debug.Log("techa2");
            Saltar(4);
        }
        else if (Input.GetKeyDown("5")) {
            Debug.Log("techa2");
            Saltar(5);
        }



    }
}
