using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    [Header("Configuracion spawn SO")]
    [SerializeField] private SpawnStatsSO spawnData;
    [SerializeField] private Transform posMin;
    [SerializeField] private Transform posMax;

    private int oleadaNum;
    private int enemigosSpawnNum;
    private int killsNum;

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
        StartCoroutine(ControlOleadas());
    }

    private IEnumerator ControlOleadas()
    {
        while (true)
        {
            for (int i = 0; i < spawnData.oleadas[oleadaNum].maxEnemigos; i++)
            {
                SpawnOleada();
                enemigosSpawnNum++;
                yield return new WaitForSeconds(spawnData.oleadas[oleadaNum].tiempoEntreSpawns);
            }

            yield return new WaitUntil(() => killsNum >= spawnData.oleadas[oleadaNum].killsMax);

            yield return new WaitForSeconds(spawnData.oleadas[oleadaNum].tiempoEntreSpawns);

            enemigosSpawnNum = 0;
            killsNum = 0;
            oleadaNum++;

            if (oleadaNum >= spawnData.oleadas.Count)
            {
                //win condition o el boss
            }
        }
    }

    // Contador para kills
    public void Kill()
    {
        killsNum++;
    }
    // Spawnea una oleada de enemigos
    private void SpawnOleada()
    {
        Instantiate(spawnData.oleadas[oleadaNum].enemigoConfig.prefabEnemigo, RandomSpawnPoint(), transform.rotation);
        enemigosSpawnNum++;
    }
    private Vector2 RandomSpawnPoint()
    {
        Vector2 spawnPoint;
        if (Random.Range(0f, 1f) > 0.5)
        {
            spawnPoint.x = Random.Range(posMin.position.x, posMax.position.x);
            if (Random.Range(0f, 1f) > 0.5)
            {
                spawnPoint.y = posMin.position.y;
            }
            else
            {
                spawnPoint.y = posMax.position.y;
            }
        }
        else
        {
            spawnPoint.y = Random.Range(posMin.position.y, posMax.position.y);
            if (Random.Range(0f, 1f) > 0.5)
            {
                spawnPoint.x = posMin.position.x;
            }
            else
            {
                spawnPoint.x = posMax.position.x;
            }
        }
        return spawnPoint;
    }
}