using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    private float damage;
    private float fuerzaDisparo;
    private float tiempoVida;

    private void Start()
    {
        DispararHaciaJugador();
        Destroy(gameObject, tiempoVida);
    }
    // Pasar damage del enemigo
    public void ConfigurarDamageDisparo(float damageEnemigo)
    {
        damage = damageEnemigo;
    }
    // Pasar fuerda del disparo del enemigo
    public void ConfigurarFuerzaDisparo(float fuerzaEnemigo)
    {
        fuerzaDisparo = fuerzaEnemigo;
    }
    // Pasar tiempo de vida para bala
    public void ConfigurarTiempoVida(float tiempoBala)
    {
        tiempoVida = tiempoBala;
    }
    // Disparar bala
    private void DispararHaciaJugador()
    {
        if (JugadorController.Instance == null) return;

        Vector2 dir = (JugadorController.Instance.transform.position - transform.position).normalized;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.linearVelocity = dir * fuerzaDisparo;
    }
    // Colision bala
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            JugadorController.Instance.RecibirDamage(damage);
            Destroy(gameObject);
        }
    }
}