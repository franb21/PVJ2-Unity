using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PistolaData", menuName = "ScriptableObjects/PistolaData")]
public class StatsScriptableObjet : ScriptableObject
{
    [Header("Config inicial arma")]
    [SerializeField] private GameObject proyectilPrefab;

    [Header("Stats iniciales")]
    [SerializeField] private float cooldown;
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private int cantidad;

    public float Cooldown { get => cooldown; }
    public float Damage { get => damage; }
    public float Speed { get => speed; }
    public int Cantidad { get => cantidad; }
    public GameObject ProyectilPrefab { get => proyectilPrefab; }
}
