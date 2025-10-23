using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    public static PoolController Instance;

    [System.Serializable]
    public class Pool
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private int cantidadInicial;
        private List<GameObject> objetos = new List<GameObject>();
        public GameObject Prefab { get => prefab; }
        public int CantidadInicial { get => cantidadInicial; }
        public List<GameObject> Objetos { get => objetos; set => objetos = value; }
    }

    [SerializeField] private Pool[] pools;

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
        InicializarPools();
    }
    // Crea los objetos iniciales de cada pool
    private void InicializarPools()
    {
        for (int i = 0; i < pools.Length; i++)
        {
            for (int j = 0; j < pools[i].CantidadInicial; j++)
            {
                GameObject obj = Instantiate(pools[i].Prefab);
                obj.SetActive(false);
                pools[i].Objetos.Add(obj);
            }
        }
    }
    // Devuelve un objeto libre del pool
    public GameObject GetPooledObject(GameObject prefab, Vector3 posicion, Quaternion rotacion)
    {
        for (int i = 0; i < pools.Length; i++)
        {
            if (pools[i].Prefab == prefab)
            {
                for (int j = 0; j < pools[i].Objetos.Count; j++)
                {
                    GameObject obj = pools[i].Objetos[j];
                    if (!obj.activeInHierarchy)
                    {
                        obj.transform.position = posicion;
                        obj.transform.rotation = rotacion;
                        obj.SetActive(true);
                        return obj;
                    }
                }
                // Si no hay objetos libres en el pool crea uno y lo aggrega
                GameObject nuevo = Instantiate(prefab, posicion, rotacion);
                pools[i].Objetos.Add(nuevo);
                return nuevo;
            }
        }
        return null;
    }
}