using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnData", menuName = "ScriptableObjects/SpawnData")]
public class SpawnStatsSO : ScriptableObject
{
    [System.Serializable]
    public class EnemigoConfiguracion
    {
        [Header("Prefab de enemigo")]
        public GameObject prefabEnemigo;

        [Header("Multiplicadores Difucultad para este enemigo")]
        public float multVida;
        public float multDamage;
        public float multVelocidad;
    }

    [System.Serializable]
    public class Oleada
    {
        [Header("Configuracion del enemigo de esta oleada")]
        public EnemigoConfiguracion enemigoConfig;

        [Header("Configuracion spawn")]
        public float tiempoEntreSpawns;
        public int maxEnemigos;
        public int killsMax;

        [Header("Configuracion modo enjambre")]
        public bool spawnEnjambre = false;
        public int cantidadEnemigosEnjambre;
        public float radioEnjambre;
        public float dispersion;
    }

    [Header("Lista de Oleadas")]
    public List<Oleada> oleadas;
}