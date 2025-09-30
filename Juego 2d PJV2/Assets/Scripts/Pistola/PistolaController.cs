using UnityEngine;
public class PistolaController : MonoBehaviour
{
    private Pistola pistola;
    private Vector2 direccion;
    private Rigidbody2D rb;

    // Dispara la bala en la direccion donde mira y se destruye
    void Start()
    {
        pistola = GameObject.Find("Pistola").GetComponent<Pistola>();
        rb = GetComponent<Rigidbody2D>();
        direccion = JugadorController.Instance.UltimaDireccion;
        rb.linearVelocity = direccion.normalized * pistola.Speed;
        Destroy(gameObject, 3f);
    }

    // Detecta colision con enemigo y lo daña
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            Enemigo enemigo = collision.GetComponent<Enemigo>();
            if (enemigo != null)
            {
                enemigo.RecibirDamage(pistola.Damage);
                Destroy(gameObject);
                //if (!pistola.penetracion) //Posible penetracion
                //{
                //    Destroy(gameObject);
                //}
            }
        }
    }
}