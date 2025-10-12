
using UnityEngine;

[CreateAssetMenu(fileName = "EnemigoData", menuName = "ScriptableObjects/EnemigoData")]
public class EnemigoStatsSO : ScriptableObject
{
    [Header("Stats del enemigo")]
    [SerializeField] private float vida;
    [SerializeField] private float damage;
    [SerializeField] private float velocidad;
    [SerializeField] private int experienciaSuelta;

    [Header("Configuracion enemigo que dispara")]
    [SerializeField] private GameObject balaPrefab;
    [SerializeField] private float tiempoEntreDisparos;
    [SerializeField] private float tiempoQuieto;
    [SerializeField] private float retrocesoDistancia;
    [SerializeField] private float fuerzaDisparo;
    public float Vida { get => vida; }
    public float Damage { get => damage; }
    public float Velocidad { get => velocidad; }
    public int Exp { get => experienciaSuelta; }
    public float TiempoEntreDisparos { get => tiempoEntreDisparos; }
    public float TiempoQuieto { get => tiempoQuieto; }
    public float RetrocesoDistancia { get => retrocesoDistancia; }
    public float FuerzaDisparo { get => fuerzaDisparo; }
    public GameObject BalaPrefab { get => balaPrefab; }
}