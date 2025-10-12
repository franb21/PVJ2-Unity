using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [Header("Configuracion de Spawn")]
    public Transform spawnN;
    public Transform spawnS;
    public Transform spawnW;
    public Transform spawnE;
    public Transform spawnNW;
    public Transform spawnNE;
    public Transform spawnSW;
    public Transform spawnSE;
    
    [System.Serializable]
    public class Oleada
    {
        public GameObject prefabEnemigo;
        public float tiempoEntreSpawns;
        public float tiempoSiguienteSpawn;
        public int maxEnemigos;
        public int enemigosSpawnNum;
        public int killsMax;
        public int killsNum;
    }
    public List<Oleada> oleadas;
    public int oleadaNum;
    public static Spawn Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        oleadas[oleadaNum].tiempoSiguienteSpawn = Time.time + oleadas[oleadaNum].tiempoEntreSpawns;
    }
    // Control de oleadas
    private void Update()
    {
        //Spawn
        if (Time.time >= oleadas[oleadaNum].tiempoSiguienteSpawn && oleadas[oleadaNum].enemigosSpawnNum < oleadas[oleadaNum].maxEnemigos)
        {
            SpawnOleada();
            oleadas[oleadaNum].enemigosSpawnNum += 8;
            oleadas[oleadaNum].tiempoSiguienteSpawn = Time.time + oleadas[oleadaNum].tiempoEntreSpawns;
        }
        // Avanza a la siguiente
        if (oleadas[oleadaNum].enemigosSpawnNum >= oleadas[oleadaNum].maxEnemigos && oleadas[oleadaNum].killsNum >= oleadas[oleadaNum].killsMax)
        {
            oleadas[oleadaNum].enemigosSpawnNum = 0;
            oleadas[oleadaNum].killsNum = 0;

            if (oleadas[oleadaNum].tiempoEntreSpawns > 0.5f)
            {
                oleadas[oleadaNum].tiempoEntreSpawns *= 0.8f;
            }

            oleadaNum++;
            // Se reinicia
            if (oleadaNum >= oleadas.Count)
            {
                oleadaNum = 0;
            }
            oleadas[oleadaNum].tiempoSiguienteSpawn = Time.time + oleadas[oleadaNum].tiempoEntreSpawns;
        }
    }
    // Contador para kills
    public void Kill()
    {
        oleadas[oleadaNum].killsNum++;
    }
    // Spawnea una oleada de enemigos
    private void SpawnOleada()
    {
        GameObject enemigo1 = Instantiate(oleadas[oleadaNum].prefabEnemigo);
        enemigo1.transform.position = spawnN.position;

        GameObject enemigo2 = Instantiate(oleadas[oleadaNum].prefabEnemigo);
        enemigo2.transform.position = spawnS.position;

        GameObject enemigo3 = Instantiate(oleadas[oleadaNum].prefabEnemigo);
        enemigo3.transform.position = spawnW.position;

        GameObject enemigo4 = Instantiate(oleadas[oleadaNum].prefabEnemigo);
        enemigo4.transform.position = spawnE.position;

        GameObject enemigo5 = Instantiate(oleadas[oleadaNum].prefabEnemigo);
        enemigo5.transform.position = spawnNW.position;

        GameObject enemigo6 = Instantiate(oleadas[oleadaNum].prefabEnemigo);
        enemigo6.transform.position = spawnNE.position;

        GameObject enemigo7 = Instantiate(oleadas[oleadaNum].prefabEnemigo);
        enemigo7.transform.position = spawnSW.position;

        GameObject enemigo8 = Instantiate(oleadas[oleadaNum].prefabEnemigo);
        enemigo8.transform.position = spawnSE.position;
    }
}