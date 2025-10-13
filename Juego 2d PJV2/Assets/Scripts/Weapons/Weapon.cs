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

        damageText = "Mejora de da�o - Actual: " + damage + " -- Mejora: +" + weaponData.DamageMejora;
        cooldownText = "Mejora de cooldown - Actual: " + cooldown + " -- Mejora: +" + weaponData.CooldownMejora;
        cantidadText = "Mejora de cantidad disparos - Actual: " + cantidad + " -- Mejora: +" + weaponData.CantidadMejora;
        areaText = "Mejora de rango - Actual: " + area + " -- Mejora: +" + weaponData.AreaMejora;
    }
    //Mejora da�o
    public void MejorarDamage()
    {
        damage += weaponData.DamageMejora;
        damageLevel++;
        damageText = "Mejora de da�o - Actual:" + damage.ToString("0") + "- Mejora+ " + weaponData.DamageMejora.ToString("0");
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
    //Mejora tama�o del arma
    public void MejorarArea()
    {
        area += weaponData.AreaMejora;
        areaLevel++;
        areaText = "Mejora de Area -Actual: " + area.ToString("0") + "- Mejora+ " + weaponData.AreaMejora.ToString("0");

        if (areaLevel >= weaponData.MaxArea)
        {
            areaText = area.ToString("0") + " ---Al maximo---";
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
}