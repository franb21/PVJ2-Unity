
using UnityEngine;

[CreateAssetMenu(fileName = "EnemigoData", menuName = "ScriptableObjects/EnemigoData")]
public class EnemigoStatsSO : ScriptableObject
{

    [Header("Stats del enemigo")]
    [SerializeField] private float vida;
    [SerializeField] private float damage;
    [SerializeField] private float velocidad;
    [SerializeField] private int experienciaSuelta;

    [Header("Configuracion enemigo Dispara")]
    [SerializeField] private GameObject balaPrefab;
    [SerializeField] private float tiempoEntreDisparos;
    [SerializeField] private float tiempoQuieto;
    [SerializeField] private float retrocesoDistancia;

    [Header("Configuracion Bala")]
    [SerializeField] private float fuerzaDisparo;
    [SerializeField] private float tiempoDeVidaBala;

    [Header("Configuracion enemgio Enjambre")]
    [SerializeField] private float tiempoDeVidaEnemigo;

    [Header("Configuracion enemigo Boss")]
    [SerializeField] private GameObject prefabBalaBoss;
    [SerializeField] private GameObject prefabEnemgiosInvocacion;

    [SerializeField] private float tiempoEntreEstados;
    [SerializeField] private float tiempoEntreDisparosBoss;
    [SerializeField] private float duracionDisparar;
    [SerializeField] private float tiempoCargaEmbestida;
    [SerializeField] private float velocidadEmbestida;
    [SerializeField] private int cantidadEnemigosInvocados;
    [SerializeField] private float radioInvocacion;
    [SerializeField] private float tiempoInvocacion;
    [SerializeField] private float tiempoPostInvocacion;

    [Header("Efectos")]
    [SerializeField] private GameObject particulasMuerte;
    [SerializeField] private GameObject efectoDamage;
    public float Vida { get => vida; }
    public float Damage { get => damage; }
    public float Velocidad { get => velocidad; }
    public int Exp { get => experienciaSuelta; }
    public float TiempoEntreDisparos { get => tiempoEntreDisparos; }
    public float TiempoQuieto { get => tiempoQuieto; }
    public float RetrocesoDistancia { get => retrocesoDistancia; }
    public float FuerzaDisparo { get => fuerzaDisparo; }
    public GameObject BalaPrefab { get => balaPrefab; }
    public float TiempoDeVidaEnemigo { get => tiempoDeVidaEnemigo; }
    public float TiempoDeVidaBala { get => tiempoDeVidaBala; }
    public float TiempoEntreEstados { get => tiempoEntreEstados; }
    public float TiempoEntreDisparosBoss { get => tiempoEntreDisparosBoss; }
    public float TiempoCargaEmbestida { get => tiempoCargaEmbestida; }
    public float VelocidadEmbestida { get => velocidadEmbestida; }
    public int CantidadEnemigosInvocados { get => cantidadEnemigosInvocados; }
    public float RadioInvocacion { get => radioInvocacion; }
    public float TiempoInvocacion { get => tiempoInvocacion; }
    public float TiempoPostInvocacion { get => tiempoPostInvocacion; }
    public GameObject PrefabBalaBoss { get => prefabBalaBoss; }
    public GameObject PrefabEnemgiosInvocacion { get => prefabEnemgiosInvocacion; }
    public float DuracionDisparar { get => duracionDisparar; }
    public GameObject ParticulasMuerte { get => particulasMuerte; }
    public GameObject EfectoDamage { get => efectoDamage; }
}