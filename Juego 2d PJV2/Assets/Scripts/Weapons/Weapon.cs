using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // ScriptableObject
    [SerializeField] private WeaponStatsSO weaponData;

    //Stats actuales
    private float damage;
    private float cooldown;
    private int cantidad;
    private float area;

    // Nivel de mejora acutal
    private int damageLevel;
    private int cooldownLevel;
    private int cantidadLevel;
    private int areaLevel;

    // Text de valores de mejoras
    private string damageText;
    private string cooldownText;
    private string cantidadText;
    private string areaText;

    private int mejorasEnTotal = 0;
    private int limiteDeMejoras;

    public float Damage { get => damage; }
    public float Cooldown { get => cooldown; }
    public int Cantidad { get => cantidad; }
    public string DamageText { get => damageText; }
    public string CooldownText { get => cooldownText; }
    public string CantidadText { get => cantidadText; }
    public WeaponStatsSO WeaponData { get => weaponData; }
    public float Area { get => area; }
    public int AreaLevel { get => areaLevel; }
    public string AreaText { get => areaText; }

    private void Awake()
    {
        damage = weaponData.Damage;
        cooldown = weaponData.Cooldown;
        cantidad = weaponData.Cantidad;
        area = weaponData.Area;
        limiteDeMejoras = (weaponData.MaxDamage + weaponData.MaxCooldown + weaponData.MaxCantidad + weaponData.MaxArea);

        cooldownText = "+COOLDOWN";
        damageText = "+DAMAGE";
        areaText = "+AREA";
        cantidadText = "+AMOUNT";

        if (IsMaxCooldown())
        {
            cooldownText = "COOLDOWN MAX!";
        }
        if (IsMaxDamage())
        {
            damageText = "DAMAGE MAX!";
        }
        if (IsMaxArea())
        {
            areaText = "AREA MAX!";
        }
        if (IsMaxCantidad())
        {
            cantidadText = "AMOUNT MAX!";
        }
    }
    //Mejora daño
    public void MejorarDamage()
    {
        damage += weaponData.DamageMejora;
        damageLevel++;
        mejorasEnTotal++;

        if (IsMaxDamage())
        {
            damageText = "\nDAMAGE MAX!";
        }
    }
    //Mejora cooldown
    public void MejorarCooldown()
    {
        cooldown -= weaponData.CooldownMejora;
        cooldownLevel++;
        mejorasEnTotal++;

        if (IsMaxCooldown())
        {
            cooldownText = "COOLDOWN MAX!";
        }
    }
    //Mejora cantidad de balas
    public void MejorarCantidad()
    {
        cantidad += weaponData.CantidadMejora;
        cantidadLevel++;
        mejorasEnTotal++;

        if (IsMaxCantidad())
        {
            cantidadText = "AMOUNT MAX!";
        }
    }
    //Mejora tamaño del arma
    public void MejorarArea()
    {
        area += weaponData.AreaMejora;
        areaLevel++;
        mejorasEnTotal++;

        if (IsMaxArea())
        {
            areaText = "AREA MAX!";
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
    public bool IsMaxCantidad()
    {
        return cantidadLevel >= weaponData.MaxCantidad;
    }
    public bool IsMaxArea()
    {
        return areaLevel >= weaponData.MaxArea;
    }
    // Si llego al maximo de mejoras
    public bool MaxMejoras()
    {
        return mejorasEnTotal >= limiteDeMejoras;
    }
}