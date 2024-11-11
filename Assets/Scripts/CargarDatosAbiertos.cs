using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class CargarDatosAbiertos : MonoBehaviour {

    [Header("Datos")]
    //public Transform cam;
    public List<TextAsset> datafiles;

    [Header("Mapas")]
    public Transform referenciaMapaGrandeA;
    public Transform referenciaMapaGrandeB;
    public Transform padreDatos;
    Vector2 referencia1 = new Vector2(-81.728606f, 12.479517f);
    Vector2 referencia2 = new Vector2(-65.484277f, -2.563717f);

    float deltaAltura = 0.01f;
    //float escalaIcono = 0.1f;

    [Header("Marcas")]

    public GameObject prefabM;


    string[,] dataM;

    public ParticleSystem[] ps;


// ------------------------------------------------------------------------------
    void Start() {

        //dataM = LoadAllData(datafiles[0]);

        //CargarDatosCMH_Masacres();

        CargarDatosCMH_MasacresParticulas();
        CargarDatosCMH_MinasParticulas();
        CargarDatos_DA_DistritosParticulas();

        //CoordenadasGPSaUnity(-74.056522f, 4.666723f); // bogota

        //prefabM.transform.position = CoordenadasGPSaUnity(-74.056522f, 4.666723f);



    }
// ------------------------------------------------------------------------------
    void CargarDatosCMH_Masacres() {


        dataM = LoadAllData(datafiles[0]);

        string name = "", latitud = "", longitud = "", hog = "";
        float latF, longtF;


        //ParticleSystem.Particle[] particles = new ParticleSystem.Particle[dataM.GetLength(0)];
        //ps.Emit(dataM.GetLength(0));
        //ps.GetParticles(particles);

        for (int n = 1; n < dataM.GetLength(0); n++) {

            if (string.IsNullOrEmpty(dataM[n, 0]))
                break;


            name = dataM[n, 2];
            hog = dataM[n, 4];
            latitud = dataM[n, 17];
            longitud = dataM[n, 18];


            latF = float.Parse(latitud);
            longtF = float.Parse(longitud);

            Vector3 posNueva = CoordenadasGPSaUnity(longtF, latF);

            GameObject nuevodato = Instantiate(prefabM, posNueva, Quaternion.identity);
            //GameObject nuevodato = Instantiate(prefabM, posNueva, Quaternion.Euler(90,0,0));
                nuevodato.transform.parent = padreDatos;

            //particles[n].position = posNueva;
            //particles[n].remainingLifetime = Mathf.Infinity;

        }

        //ps.SetParticles(particles, particles.Length);

        //Debug.LogWarning(name);


    }
// ------------------------------------------------------------------------------
    public void CargarDatosCMH_MasacresParticulas() {

        dataM = LoadAllData(datafiles[0]);

        string latitud = "";
        string longitud = "";
        float latF, longtF;

        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[dataM.GetLength(0)];
        ps[0].Emit(dataM.GetLength(0));
        ps[0].GetParticles(particles);

        //ParticleSystem.MainModule psmain = ps.main;
        //psmain.startSize = new ParticleSystem.MinMaxCurve(escalaIcono, escalaIcono); ;
        

        for (int n = 1; n < dataM.GetLength(0); n++) {

            if (string.IsNullOrEmpty(dataM[n, 0]))
                break;

            //name = dataM[n, 2];
            //hog = dataM[n, 4];
            latitud = dataM[n, 17];
            longitud = dataM[n, 18];

            latF = float.Parse(latitud);
            longtF = float.Parse(longitud);

            Vector3 posNueva = CoordenadasGPSaUnity(longtF, latF);

            //GameObject nuevodato = Instantiate(prefabM, posNueva, Quaternion.identity);
            //GameObject nuevodato = Instantiate(prefabM, posNueva, Quaternion.Euler(90,0,0));
                //nuevodato.transform.parent = padreDatos;

            particles[n].position = posNueva;
            particles[n].remainingLifetime = Mathf.Infinity;

            //Debug.LogWarning(n);

        }

        ps[0].SetParticles(particles, particles.Length);

        //Debug.LogWarning(name);


    }
// ------------------------------------------------------------------------------
    public void CorrutinaAnimacion() {

        StartCoroutine(AnimacionDatosCMH_MasacresParticulas());

    }
// ------------------------------------------------------------------------------
    IEnumerator AnimacionDatosCMH_MasacresParticulas()
    {

        dataM = LoadAllData(datafiles[0]);

        string latitud = "";
        string longitud = "";
        float latF, longtF;

        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[dataM.GetLength(0)];
        ps[0].Emit(dataM.GetLength(0));
        ps[0].GetParticles(particles);

        //ParticleSystem.MainModule psmain = ps.main;
        //psmain.startSize = new ParticleSystem.MinMaxCurve(escalaIcono, escalaIcono); ;


        for (int n = 1; n < dataM.GetLength(0); n++) {

            if (string.IsNullOrEmpty(dataM[n, 0]))
                break;

            //name = dataM[n, 2];
            //hog = dataM[n, 4];
            latitud = dataM[n, 17];
            longitud = dataM[n, 18];

            latF = float.Parse(latitud);
            longtF = float.Parse(longitud);

            Vector3 posNueva = CoordenadasGPSaUnity(longtF, latF);

            //GameObject nuevodato = Instantiate(prefabM, posNueva, Quaternion.identity);
            //GameObject nuevodato = Instantiate(prefabM, posNueva, Quaternion.Euler(90,0,0));
            //nuevodato.transform.parent = padreDatos;

            particles[n].position = posNueva;
            particles[n].remainingLifetime = Mathf.Infinity;

            //Debug.LogWarning(n);

            if(n%10 == 0) {
                ps[0].SetParticles(particles, n);
                yield return new WaitForEndOfFrame();
            }


        }

        ps[0].SetParticles(particles, particles.Length);

        //Debug.LogWarning(name);
        yield return null;

    }
    // ------------------------------------------------------------------------------
    public void CargarDatosCMH_MinasParticulas() {

        dataM = LoadAllData(datafiles[1]);

        string latitud = "";
        string longitud = "";
        float latF, longtF;

        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[dataM.GetLength(0)];
        ps[1].Emit(dataM.GetLength(0));
        ps[1].GetParticles(particles);

        //ParticleSystem.MainModule psmain = ps.main;
        //psmain.startSize = new ParticleSystem.MinMaxCurve(escalaIcono, escalaIcono); ;


        for (int n = 1; n < dataM.GetLength(0); n++)
        {

            if (string.IsNullOrEmpty(dataM[n, 0]))
                break;

            //name = dataM[n, 2];
            //hog = dataM[n, 4];
            latitud = dataM[n, 30];
            longitud = dataM[n, 31];

            latF = float.Parse(latitud);
            longtF = float.Parse(longitud);

            Vector3 posNueva = CoordenadasGPSaUnity(longtF, latF);

            //GameObject nuevodato = Instantiate(prefabM, posNueva, Quaternion.identity);
                //nuevodato.transform.parent = padreDatos;

            particles[n].position = posNueva;
            particles[n].remainingLifetime = Mathf.Infinity;

        }

        ps[1].SetParticles(particles, particles.Length);

        //Debug.LogWarning(name);


    }
    // ------------------------------------------------------------------------------
    public void CargarDatos_DA_DistritosParticulas() {

        dataM = LoadAllData(datafiles[2]);

        string latitud;
        string longitud;
        float latF, longtF;

        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[dataM.GetLength(0)];
        ps[2].Emit(dataM.GetLength(0));
        ps[2].GetParticles(particles);

        //ParticleSystem.MainModule psmain = ps.main;
        //psmain.startSize = new ParticleSystem.MinMaxCurve(escalaIcono, escalaIcono); ;


        for (int n = 1; n < dataM.GetLength(0); n++)
        {

            if (string.IsNullOrEmpty(dataM[n, 0]))
                break;

            //name = dataM[n, 2];
            //hog = dataM[n, 4];
            latitud = dataM[n, 9];
            longitud = dataM[n, 10];

            latF = float.Parse(latitud);
            longtF = float.Parse(longitud);

            Vector3 posNueva = CoordenadasGPSaUnity(longtF, latF);

            //GameObject nuevodato = Instantiate(prefabM, posNueva, Quaternion.identity);
            //nuevodato.transform.parent = padreDatos;

            particles[n].position = posNueva;
            particles[n].remainingLifetime = Mathf.Infinity;

        }

        ps[2].SetParticles(particles, particles.Length);

        //Debug.LogWarning(name);


    }
// ------------------------------------------------------------------------------
    void CargarDatos_DA_DesaparecidosParticulas() {

        dataM = LoadAllData(datafiles[3]);

        string latitud = "";
        string longitud = "";
        float latF, longtF;

        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[dataM.GetLength(0)];
        ps[3].Emit(dataM.GetLength(0));
        ps[3].GetParticles(particles);

        //ParticleSystem.MainModule psmain = ps.main;
        //psmain.startSize = new ParticleSystem.MinMaxCurve(escalaIcono, escalaIcono); ;


        for (int n = 1; n < dataM.GetLength(0); n++)
        {

            if (string.IsNullOrEmpty(dataM[n, 0]))
                break;

            //name = dataM[n, 2];
            //hog = dataM[n, 4];
            latitud = dataM[n, 9];
            longitud = dataM[n, 10];

            latF = float.Parse(latitud);
            longtF = float.Parse(longitud);

            Vector3 posNueva = CoordenadasGPSaUnity(longtF, latF);

            //GameObject nuevodato = Instantiate(prefabM, posNueva, Quaternion.identity);
            //nuevodato.transform.parent = padreDatos;

            particles[n].position = posNueva;
            particles[n].remainingLifetime = Mathf.Infinity;

        }

        ps[3].SetParticles(particles, particles.Length);

        //Debug.LogWarning(name);


    }
    // ------------------------------------------------------------------------------
    Vector3 CoordenadasGPSaUnity(float longitud, float latitud) {


        float a = Mathf.InverseLerp(referencia1.x, referencia2.x, longitud);
        float b = Mathf.InverseLerp(referencia1.y, referencia2.y, latitud);
        
        float newLon = Mathf.Lerp(referenciaMapaGrandeA.position.x, referenciaMapaGrandeB.position.x, a);
        float newLat = Mathf.Lerp(referenciaMapaGrandeA.position.z, referenciaMapaGrandeB.position.z, b);

        //Vector3 resultado = new Vector3(newLon,0.0f,newLat);
        float altura = CoordenadasAltura(newLon, newLat);
        Vector3 resultado = new Vector3(newLon, altura + deltaAltura, newLat);



        return resultado;

    }
// ------------------------------------------------------------------------------
    float CoordenadasAltura(float posX, float PosY) {

        Vector3 direction = Vector3.down;
        Vector3 posicion = new Vector3(posX, 0.5f, PosY);
        // Variable para almacenar la información de colisión del rayo
        RaycastHit hit;

        // Lanza el rayo desde la posición especificada, hacia abajo y con un rango máximo
        if (Physics.Raycast(posicion, direction, out hit, 1)) {
            // Verificar si el objeto con el que se colisionó tiene un MeshCollider
            if (hit.collider is MeshCollider) {
                // Devuelve la altura en la que ocurrió la colisión
                return hit.point.y;
            }
            else {
                Debug.LogError("falló detector de altura");
                return 0;
            }
        }

        return 0;

    }
// ------------------------------------------------------------------------------
    string[,] LoadAllData(TextAsset datafile) {

        string s = datafile.text;
        string[] rows = s.Split('\n');

        string[,] data = new string[rows.Length, rows[0].Split('\t').Length];

        for (int n = 0; n < rows.Length; n++)
        {

            string[] columns = (rows[n].Trim()).Split('\t');

            for (int m = 0; m < columns.Length; m++)
            {
                //print($"[{n},{m}]{columns[m]}");
                data[n, m] = columns[m];
            }
        }

        return data;

    }
}
