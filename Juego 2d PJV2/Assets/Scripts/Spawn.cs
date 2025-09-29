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
    }
    public List<Oleada> oleadas;
    public int oleadaNum;

    private void Start()
    {
        oleadas[oleadaNum].tiempoSiguienteSpawn = Time.time + oleadas[oleadaNum].tiempoEntreSpawns;
    }

    private void Update()
    {
        if (Time.time >= oleadas[oleadaNum].tiempoSiguienteSpawn && oleadas[oleadaNum].enemigosSpawnNum < oleadas[oleadaNum].maxEnemigos)
        {
            SpawnOleada();
            oleadas[oleadaNum].enemigosSpawnNum += 8;
            oleadas[oleadaNum].tiempoSiguienteSpawn = Time.time + oleadas[oleadaNum].tiempoEntreSpawns;
        }

        if (oleadas[oleadaNum].enemigosSpawnNum >= oleadas[oleadaNum].maxEnemigos)
        {
            oleadas[oleadaNum].enemigosSpawnNum = 0;
            oleadaNum++;
            oleadas[oleadaNum].tiempoSiguienteSpawn = Time.time + oleadas[oleadaNum].tiempoEntreSpawns;

        }
    }

    // Spawnea una oleada de enemigos
    private void SpawnOleada()
    {
        //if (GameObject.FindGameObjectsWithTag("Enemigo").Length >= maxEnemigos) return;
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