using UnityEngine;

public class Pistola : MonoBehaviour
{
    // ScriptableObject
    [SerializeField] private StatsScriptableObjet pistolaData;
    
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


    private void Start()
    {
        damage = pistolaData.Damage;
        cooldown = pistolaData.Cooldown;
        speed = pistolaData.Speed;
        cantidad = pistolaData.Cantidad;

        damageText = pistolaData.DamageText;
        cooldownText = pistolaData.CooldownText;
        speedText = pistolaData.SpeedText;
        cantidadText = pistolaData.CantidadText;
    }
    void Update()
    {
        tiempoDisparo -= Time.deltaTime;

        if (tiempoDisparo <= 0)
        {
            tiempoDisparo = cooldown;
            // Instancia el proyectil en la posicion y segun la cantidad aumenta
            Vector2 dir = JugadorController.Instance.ultimaDireccion.normalized;
            for (int i = 0; i < cantidad; i++)
            {
                Vector3 offset = dir * (i * -0.5f);
                Instantiate(pistolaData.ProyectilPrefab, transform.position + offset, transform.rotation);
            }
        }
    }
    public void MejorarCooldown()
    {
        cooldown -= pistolaData.CooldownMejora;
        cooldownLevel++;
        cooldownText = cooldown.ToString("0") + " / +" + pistolaData.CooldownMejora.ToString("0");

        if (cooldownLevel >= pistolaData.MaxCooldown)
        {
            cooldownText = cooldown.ToString("0") + " ---Al maximo---";
        }
    }

    public void MejorarDamage()
    {
        damage += pistolaData.DamageMejora;
        damageLevel++;
        damageText = damage.ToString("0") + " / +" + pistolaData.DamageMejora.ToString("0");
        Debug.Log(" pistola mejorada" + damageText);
        if (damageLevel >= pistolaData.MaxDamage)
        {
            damageText = damage.ToString("0") + " ---Al maximo---";
        }
    }

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