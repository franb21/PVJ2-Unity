using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    private float damage;
    private float fuerzaDisparo;
    private float tiempoVida;
    private float tiempoActual;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Reiniciar variables
    private void OnEnable()
    {
        tiempoActual = 0;
        rb.linearVelocity = Vector2.zero;
    }
    private void Update()
    {
        tiempoActual += Time.deltaTime;
        if (tiempoActual >= tiempoVida) // si pasa el tiempo vuellve
            gameObject.SetActive(false);
    }
    // Configurar bala
    public void ActivarBala(Vector3 posicion, Vector2 dir, float fuerza, float tiempoVidaBala, float damageEnemigo)
    {
        transform.position = posicion;
        damage = damageEnemigo;
        fuerzaDisparo = fuerza;
        tiempoVida = tiempoVidaBala;
        tiempoActual = 0;
        rb.linearVelocity = dir.normalized * fuerzaDisparo;
        gameObject.SetActive(true);
    }
    // Colision bala
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            JugadorController.Instance.RecibirDamage(damage);
            gameObject.SetActive(false); // vuelve al pool cuando colisiona con jugador
        }
    }
}