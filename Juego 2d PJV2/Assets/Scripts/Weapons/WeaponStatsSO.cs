using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData")]
public class WeaponStatsSO : ScriptableObject
{
    [Header("Config inicial arma")]
    [SerializeField] private GameObject prefabWeapon;
    public string nombre;
    public Sprite icono;
    public string descripcion;

    [Header("Stats iniciales")]
    [SerializeField] private float cooldown;
    [SerializeField] private float damage;
    [SerializeField] private int cantidad;
    [SerializeField] private float area;


    [Header("Incrementos por mejora")]
    [SerializeField] private float cooldownMejora;
    [SerializeField] private float damageMejora;
    [SerializeField] private int cantidadMejora;
    [SerializeField] private float areaMejora;

    [Header("Limites de cantidad de mejoras")]
    [SerializeField] private int maxCooldown;
    [SerializeField] private int maxDamage;
    [SerializeField] private int maxCantidad;
    [SerializeField] private int maxArea;

    public float Cooldown { get => cooldown; }
    public float Damage { get => damage; }
    public int Cantidad { get => cantidad; }
    public GameObject PrefabWeapon { get => prefabWeapon; }
    public float CooldownMejora { get => cooldownMejora; }
    public float DamageMejora { get => damageMejora; }
    public int CantidadMejora { get => cantidadMejora; }
    public int MaxCooldown { get => maxCooldown; }
    public int MaxDamage { get => maxDamage; }
    public int MaxCantidad { get => maxCantidad; }
    public float Area { get => area; }
    public float AreaMejora { get => areaMejora; }
    public int MaxArea { get => maxArea; }
}
