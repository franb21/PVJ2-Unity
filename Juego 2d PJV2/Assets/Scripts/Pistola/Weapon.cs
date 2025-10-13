using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // ScriptableObject
    [SerializeField] private WeaponStatsSO weaponData;

    //Stats actuales
    private float damage;
    private float cooldown;
    private float speed;
    private int cantidad;

    // Nivel de mejora acutal
    private int damageLevel;
    private int cooldownLevel;
    private int speedLevel;
    private int cantidadLevel;

    // Text de valores de mejoras
    private string damageText;
    private string cooldownText;
    private string speedText;
    private string cantidadText;

    public float Damage { get => damage; }
    public float Cooldown { get => cooldown; }
    public float Speed { get => speed; }
    public int Cantidad { get => cantidad; }
    public string DamageText { get => damageText; }
    public string CooldownText { get => cooldownText; }
    public string SpeedText { get => speedText; }
    public string CantidadText { get => cantidadText; }
    public WeaponStatsSO WeaponData { get => weaponData; }

    private void Start()
    {
        damage = weaponData.Damage;
        cooldown = weaponData.Cooldown;
        speed = weaponData.Speed;
        cantidad = weaponData.Cantidad;

        damageText = "Mejora de daño - Actual: " + damage + " -- Mejora: +" + weaponData.DamageMejora;
        cooldownText = "Mejora de cooldown - Actual: " + cooldown + " -- Mejora: +" + weaponData.CooldownMejora;
        speedText = "Mejora de speed - Actual: " + speed + " -- Mejora: +" + weaponData.SpeedMejora;
        cantidadText = "Mejora de cantidad disparos - Actual: " + cantidad + " -- Mejora: +" + weaponData.CantidadMejora;
    }
    //Mejora daño
    public void MejorarDamage()
    {
        damage += weaponData.DamageMejora;
        damageLevel++;
        damageText = "Mejora de daño - Actual:" + damage.ToString("0") + "- Mejora+ " + weaponData.DamageMejora.ToString("0");
        Debug.Log(" pistola mejorada" + damageText);
        if (damageLevel >= weaponData.MaxDamage)
        {
            damageText = damage.ToString("0") + " ---Al maximo---";
        }
    }
    //Mejora cooldown
    public void MejorarCooldown()
    {
        cooldown -= weaponData.CooldownMejora;
        cooldownLevel++;
        cooldownText = "Mejora de cooldown - Actual: " + cooldown.ToString("0") + "- Mejora- " + weaponData.CooldownMejora.ToString("0");

        if (cooldownLevel >= weaponData.MaxCooldown)
        {
            cooldownText = cooldown.ToString("0") + " ---Al maximo---";
        }
    }
    //Mejora velocidad
    public void MejorarSpeed()
    {
        speed += weaponData.SpeedMejora;
        speedLevel++;
        speedText = "Mejora de speed - Actual: " + speed.ToString("0") + "- Mejora+ " + weaponData.SpeedMejora.ToString("0");

        if (speedLevel >= weaponData.MaxSpeed)
        {
            speedText = speed.ToString("0") + " ---Al maximo---";
        }
    }
    //Mejora cantidad de balas
    public void MejorarCantidad()
    {
        cantidad += weaponData.CantidadMejora;
        cantidadLevel++;
        cantidadText = "Mejora de cantidad disparos -Actual: " + cantidad.ToString("0") + "- Mejora+ " + weaponData.CantidadMejora.ToString("0");

        if (cantidadLevel >= weaponData.MaxCantidad)
        {
            cantidadText = cantidad.ToString("0") + " ---Al maximo---";
        }
    }
    // Verifica si llegaron
    // al max de mexoras
    public bool IsMaxCooldown()
    {
        return cooldownLevel >= weaponData.MaxCooldown;
    }
    public bool IsMaxDamage()
    {
        return damageLevel >= weaponData.MaxDamage;
    }
    public bool IsMaxSpeed()
    {
        return speedLevel >= weaponData.MaxSpeed;
    }
    public bool IsMaxCantidad()
    {
        return cantidadLevel >= weaponData.MaxCantidad;
    }
}