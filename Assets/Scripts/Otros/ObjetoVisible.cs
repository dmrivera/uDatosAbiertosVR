using UnityEngine;
using UnityEngine.Events;

public class ObjetoVisible : MonoBehaviour {

public UnityEvent eventoOnBecameVisible;

//------------------------------------------------------------------------------------
    void OnBecameVisible() {

        eventoOnBecameVisible.Invoke();

    }

}