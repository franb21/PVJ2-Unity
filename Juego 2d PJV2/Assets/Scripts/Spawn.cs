using UnityEngine;

public class Spawn : MonoBehaviour
{
    [Header("Configuracion de Spawn")]
    public GameObject prefabEnemigo;
    public Transform jugador;
    public Transform spawnArriba;
    public Transform spawnAbajo;
    public Transform spawnIzquierda;
    public Transform spawnDerecha;
    public float tiempoEntreSpawns;
    private float tiempoSiguienteSpawn;
    public int maxEnemigos;

    private void Start()
    {
        tiempoSiguienteSpawn = Time.time + tiempoEntreSpawns;
    }

    private void Update()
    {
        if (Time.time >= tiempoSiguienteSpawn)
        {
            SpawnOleada();
            tiempoSiguienteSpawn = Time.time + tiempoEntreSpawns;
        }
    }

    // Spawnea una oleada de enemigos
    private void SpawnOleada()
    {
        if (GameObject.FindGameObjectsWithTag("Enemigo").Length >= maxEnemigos) return;
        GameObject enemigo1 = Instantiate(prefabEnemigo);
        enemigo1.transform.position = spawnArriba.position;

        GameObject enemigo2 = Instantiate(prefabEnemigo);
        enemigo2.transform.position = spawnAbajo.position;

        GameObject enemigo3 = Instantiate(prefabEnemigo);
        enemigo3.transform.position = spawnIzquierda.position;

        GameObject enemigo4 = Instantiate(prefabEnemigo);
        enemigo4.transform.position = spawnDerecha.position;
    }
}