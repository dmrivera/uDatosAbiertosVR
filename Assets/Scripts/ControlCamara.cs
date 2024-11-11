using UnityEngine;

public class ControlCamara : MonoBehaviour {
    public Transform objetivo;
    public float velocidadRotacion = 2.0f;
    public float velocidadMovimiento = 10.0f;

    private float rotacionX = 0.0f;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() {
        // Rotaci�n de la c�mara con clic derecho
        if (Input.GetMouseButton(1)) {
            float rotacionY = Input.GetAxis("Mouse X") * velocidadRotacion;
            rotacionX -= Input.GetAxis("Mouse Y") * velocidadRotacion;
            rotacionX = Mathf.Clamp(rotacionX, -90, 90);

            transform.Rotate(Vector3.up * rotacionY);
            transform.localRotation = Quaternion.Euler(rotacionX, 0, 0);
        }

        // Movimiento de la c�mara con teclas
        float movimientoHorizontal = Input.GetAxis("Horizontal") * velocidadMovimiento * Time.deltaTime;
        float movimientoVertical = Input.GetAxis("Vertical") * velocidadMovimiento * Time.deltaTime;

        transform.Translate(new Vector3(movimientoHorizontal, 0, movimientoVertical));

        // Mant�n la c�mara enfocada en el objetivo (si est� configurado)
        if (objetivo != null) {
            transform.LookAt(objetivo);
        }
    }
}