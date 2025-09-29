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
    private float tiempoDisparo = 0f;

    public float Damage { get => damage; }
    public float Cooldown { get => cooldown; }
    public float Speed { get => speed; }
    public int Cantidad { get => cantidad; }


    private void Start()
    {
        damage = pistolaData.Damage;
        cooldown = pistolaData.Cooldown;
        speed = pistolaData.Speed;
        cantidad = pistolaData.Cantidad;
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
}