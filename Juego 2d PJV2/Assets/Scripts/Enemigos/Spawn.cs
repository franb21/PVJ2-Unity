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
                yield return new WaitForSeconds(spawnData.oleadas[oleadaNum].tiempoEntreSpawns);
            }

            yield return new WaitUntil(() => killsNum >= spawnData.oleadas[oleadaNum].killsMax);

            yield return new WaitForSeconds(spawnData.oleadas[oleadaNum].tiempoEntreSpawns);

            enemigosSpawnNum = 0;
            killsNum = 0;
            oleadaNum++;

            if (oleadaNum >= spawnData.oleadas.Count)
            {
                oleadaNum = 0;
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
        // Si esta true spawenea ejambre
        if (spawnData.oleadas[oleadaNum].spawnEnjambre)
        {
            SpawnEnjambre();
        }
        else
        {
            GameObject enemigo = PoolController.Instance.GetPooledObject(spawnData.oleadas[oleadaNum].enemigoConfig.prefabEnemigo, RandomSpawnPoint(), transform.rotation);
            if (enemigo != null)
            {
                Enemigo enemgioSpaweneado = enemigo.GetComponent<Enemigo>();
                enemgioSpaweneado.AjustarStats(spawnData.oleadas[oleadaNum].enemigoConfig.multVida, spawnData.oleadas[oleadaNum].enemigoConfig.multDamage, spawnData.oleadas[oleadaNum].enemigoConfig.multVelocidad);
                enemigosSpawnNum++;
            }
        }
    }
    // Spawnea enjambre
    private void SpawnEnjambre()
    {
        Vector2 centro = RandomSpawnPoint();

        int cantidad = spawnData.oleadas[oleadaNum].cantidadEnemigosEnjambre;
        float radio = spawnData.oleadas[oleadaNum].radioEnjambre;
        float dispersion = spawnData.oleadas[oleadaNum].dispersion;

        for (int i = 0; i < cantidad; i++)
        {
            float angulo = (360f / cantidad) * i;
            Vector2 offset = new Vector2(Mathf.Cos(angulo), Mathf.Sin(angulo)) * radio;

            offset.x += Random.Range(-dispersion, dispersion);
            offset.y += Random.Range(-dispersion, dispersion);

            Vector2 posicionFinal = centro + offset;

            GameObject enemigo = PoolController.Instance.GetPooledObject(spawnData.oleadas[oleadaNum].enemigoConfig.prefabEnemigo, posicionFinal, transform.rotation);
            if (enemigo != null)
            {
                Enemigo enemgioSpaweneado = enemigo.GetComponent<Enemigo>();
                enemgioSpaweneado.AjustarStats(spawnData.oleadas[oleadaNum].enemigoConfig.multVida, spawnData.oleadas[oleadaNum].enemigoConfig.multDamage, spawnData.oleadas[oleadaNum].enemigoConfig.multVelocidad);
                enemigosSpawnNum++;
            }
        }
    }
    // Aleatorizar el punto de spawn alrededor de la camra
    private Vector2 RandomSpawnPoint()
    {
        Vector2 spawnPoint;
        if (Random.value > 0.5)
        {
            spawnPoint.x = Random.Range(posMin.position.x, posMax.position.x);
            if (Random.value > 0.5)
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
            if (Random.value > 0.5)
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