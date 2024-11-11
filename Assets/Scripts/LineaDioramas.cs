using UnityEngine;

public class LineaDioramas : MonoBehaviour {


    Transform object1; // El primer objeto a unir
    public Transform object2; // El segundo objeto a unir

    private LineRenderer lineRenderer;

    void Start() {
        // Asegúrate de tener un LineRenderer en el mismo objeto que contiene este script
        lineRenderer = GetComponent<LineRenderer>();

        object1 = transform;

        // Configura las posiciones iniciales y finales de la línea
        lineRenderer.SetPosition(0, object1.position);
        lineRenderer.SetPosition(1, object2.position);
    }

    void Update() {
        // Actualiza constantemente las posiciones de los objetos para mantener la línea conectada
        //lineRenderer.SetPosition(0, object1.position);
        lineRenderer.SetPosition(1, object2.position);
        //Debug.Log("w");
    }
}