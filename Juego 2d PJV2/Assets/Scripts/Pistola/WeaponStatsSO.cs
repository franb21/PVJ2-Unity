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
    [SerializeField] private float speed;
    [SerializeField] private int cantidad;

    [Header("Incrementos por mejora")]
    [SerializeField] private float cooldownMejora;
    [SerializeField] private float damageMejora;
    [SerializeField] private float speedMejora;
    [SerializeField] private int cantidadMejora;

    [Header("Limites de cantidad de mejoras")]
    [SerializeField] private int maxCooldown;
    [SerializeField] private int maxDamage;
    [SerializeField] private int maxSpeed;
    [SerializeField] private int maxCantidad;

    public float Cooldown { get => cooldown; }
    public float Damage { get => damage; }
    public float Speed { get => speed; }
    public int Cantidad { get => cantidad; }
    public GameObject PrefabWeapon { get => prefabWeapon; }
    public float CooldownMejora { get => cooldownMejora; }
    public float DamageMejora { get => damageMejora; }
    public float SpeedMejora { get => speedMejora; }
    public int CantidadMejora { get => cantidadMejora; }
    public int MaxCooldown { get => maxCooldown; }
    public int MaxDamage { get => maxDamage; }
    public int MaxSpeed { get => maxSpeed; }
    public int MaxCantidad { get => maxCantidad; }
}
