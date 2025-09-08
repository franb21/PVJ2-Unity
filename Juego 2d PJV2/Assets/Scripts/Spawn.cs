using UnityEngine;

public class Spawn : MonoBehaviour
{
    [Header("Configuracion de Spawn")]
    public GameObject prefabEnemigo;
    public Transform jugador;
    public Transform spawnN;
    public Transform spawnS;
    public Transform spawnW;
    public Transform spawnE;
    public Transform spawnNW;
    public Transform spawnNE;
    public Transform spawnSW;
    public Transform spawnSE;
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
        enemigo1.transform.position = spawnN.position;

        GameObject enemigo2 = Instantiate(prefabEnemigo);
        enemigo2.transform.position = spawnS.position;

        GameObject enemigo3 = Instantiate(prefabEnemigo);
        enemigo3.transform.position = spawnW.position;

        GameObject enemigo4 = Instantiate(prefabEnemigo);
        enemigo4.transform.position = spawnE.position;

        GameObject enemigo5 = Instantiate(prefabEnemigo);
        enemigo5.transform.position = spawnNW.position;

        GameObject enemigo6 = Instantiate(prefabEnemigo);
        enemigo6.transform.position = spawnNE.position;

        GameObject enemigo7 = Instantiate(prefabEnemigo);
        enemigo7.transform.position = spawnSW.position;

        GameObject enemigo8 = Instantiate(prefabEnemigo);
        enemigo8.transform.position = spawnSE.position;
    }
}