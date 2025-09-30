
using UnityEngine;

[CreateAssetMenu(fileName = "EnemigoData", menuName = "ScriptableObjects/EnemigoData")]
public class EnemigoStatsSO : ScriptableObject
{
    [Header("Stats del enemigo")]
    [SerializeField] private float vida;
    [SerializeField] private float damage;
    [SerializeField] private float velocidad;
    [SerializeField] private int experienciaSuelta;

    public float Vida { get => vida; }
    public float Damage { get => damage; }
    public float Velocidad { get => velocidad; }
    public int Exp { get => experienciaSuelta; }
}