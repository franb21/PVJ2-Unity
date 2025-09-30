using System;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    // ScriptableObject
    [SerializeField] private PistolaSatsSO pistolaData;
    
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

    private float tiempoDisparo = 0f;
    public float Damage { get => damage; }
    public float Cooldown { get => cooldown; }
    public float Speed { get => speed; }
    public int Cantidad { get => cantidad; }
    public string DamageText { get => damageText; }
    public string CooldownText { get => cooldownText; }
    public string SpeedText { get => speedText; }
    public string CantidadText { get => cantidadText; }
    public PistolaSatsSO PistolaData { get => pistolaData; }

    private void Start()
    {
        damage = pistolaData.Damage;
        cooldown = pistolaData.Cooldown;
        speed = pistolaData.Speed;
        cantidad = pistolaData.Cantidad;

        damageText = "Mejora de daño - Actual: " + damage + " -- Mejora: +" + pistolaData.DamageMejora;
        cooldownText = "Mejora de cooldown - Actual: " + cooldown + " -- Mejora: +" + pistolaData.CooldownMejora;
        speedText = "Mejora de speed - Actual: " + speed + " -- Mejora: +" + pistolaData.SpeedMejora;
        cantidadText = "Mejora de cantidad disparos - Actual: " + cantidad + " -- Mejora: +" + pistolaData.CantidadMejora;

    }
    void Update()
    {
        tiempoDisparo -= Time.deltaTime;

        if (tiempoDisparo <= 0)
        {
            tiempoDisparo = cooldown;
            // Instancia el proyectil en la posicion y segun la cantidad aumenta
            Vector2 dir = JugadorController.Instance.UltimaDireccion.normalized;
            for (int i = 0; i < cantidad; i++)
            {
                Vector3 offset = dir * (i * -0.5f);
                Instantiate(pistolaData.ProyectilPrefab, transform.position + offset, transform.rotation);
            }
        }
    }
    //Mejora daño
    public void MejorarDamage()
    {
        damage += pistolaData.DamageMejora;
        damageLevel++;
        damageText = "Mejora de daño - Actual:" + damage.ToString("0") + "- Mejora+ " + pistolaData.DamageMejora.ToString("0");
        Debug.Log(" pistola mejorada" + damageText);
        if (damageLevel >= pistolaData.MaxDamage)
        {
            damageText = damage.ToString("0") + " ---Al maximo---";
        }
    }
    //Mejora cooldown
    public void MejorarCooldown()
    {
        cooldown -= pistolaData.CooldownMejora;
        cooldownLevel++;
        cooldownText = "Mejora de daño - Actual:" + cooldown.ToString("0") + "- Mejora+ " + pistolaData.CooldownMejora.ToString("0");

        if (cooldownLevel >= pistolaData.MaxCooldown)
        {
            cooldownText = cooldown.ToString("0") + " ---Al maximo---";
        }
    }
    //Mejora velocidad
    public void MejorarSpeed()
    {
        speed += pistolaData.SpeedMejora;
        speedLevel++;
        speedText = speed.ToString("0") + " / +" + pistolaData.SpeedMejora.ToString("0");

        if (speedLevel >= pistolaData.MaxSpeed)
        {
            speedText = speed.ToString("0") + " ---Al maximo---";
        }
    }
    //Mejora cantidad de balas
    public void MejorarCantidad()
    {
        cantidad += pistolaData.CantidadMejora;
        cantidadLevel++;
        cantidadText = cantidad.ToString("0") + " / +" + pistolaData.CantidadMejora.ToString("0");

        if (cantidadLevel >= pistolaData.MaxCantidad)
        {
            cantidadText = cantidad.ToString("0") + " ---Al maximo---";
        }
    }
    // Verifica si llegaron
    // al max de mexoras
    public bool IsMaxCooldown()
    {
        return cooldownLevel >= pistolaData.MaxCooldown;
    }
    public bool IsMaxDamage()
    {
        return damageLevel >= pistolaData.MaxDamage;
    }
    public bool IsMaxSpeed()
    {
        return speedLevel >= pistolaData.MaxSpeed;
    }
    public bool IsMaxCantidad()
    {
        return cantidadLevel >= pistolaData.MaxCantidad;
    }
}