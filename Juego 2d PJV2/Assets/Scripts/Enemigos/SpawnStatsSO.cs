using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnData", menuName = "Spawn/SpawnData")]
public class SpawnStatsSO : ScriptableObject
{
    [System.Serializable]
    public class Oleada
    {
        public GameObject prefabEnemigo;
        public float tiempoEntreSpawns = 2f;
        public int maxEnemigos = 30;
        public int killsMax = 30;
    }

    [Header("Lista de Oleadas")]
    public List<Oleada> oleadas;
}