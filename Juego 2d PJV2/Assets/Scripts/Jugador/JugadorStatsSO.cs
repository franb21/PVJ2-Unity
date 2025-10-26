using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JugadorData", menuName = "ScriptableObjects/JugadorData")]
public class JugadorStatsSO : ScriptableObject
{
    [Header("Stats iniciales del jugador")]
    [SerializeField] private float vida;
    [SerializeField] private float velocidad;
    [SerializeField] private float tiempoEntreDamage;

    [Header("Aumentos por mejora")]
    [SerializeField] private int aumentoVida;
    [SerializeField] private float aumentoVelocidad;

    [Header("Config experiencia y niveles")]
    [SerializeField] private int escaladoLevels;
    [SerializeField] private int expInicial;
    [SerializeField] private int maxLevel;

    public float Vida { get => vida; }
    public float Velocidad { get => velocidad; }
    public int AumentoVida { get => aumentoVida; }
    public float AumentoVelocidad { get => aumentoVelocidad; }
    public float TiempoEntreDamage { get => tiempoEntreDamage; }
    public int MaxLevel { get => maxLevel; }
    public int EscaladoLevels { get => escaladoLevels; }
    public int ExpInicial { get => expInicial; }
}