using UnityEngine;
public class PistolaController : MonoBehaviour
{
    [SerializeField] private float velocidadBala;
    [SerializeField] private float tiempoVida;
    private Pistola pistola;
    private Vector2 direccion;
    private Rigidbody2D rb;
    private float vidaRestante;

    public void Inicializar(Pistola p, Vector2 direccionDisparo)
    {
        pistola = p;
        direccion = direccionDisparo.normalized;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        if (pistola != null)
        {
            AudioController.Instance.Play(AudioController.Instance.pistola);
            direccion = JugadorController.Instance.UltimaDireccion.normalized;
            rb.linearVelocity = direccion * velocidadBala;
            vidaRestante = tiempoVida;
        }
    }
    private void Update()
    {
        vidaRestante -= Time.deltaTime;
        if (vidaRestante <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    // Detecta colision con enemigo y lo daña
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            Enemigo enemigo = collision.GetComponent<Enemigo>();
            if (enemigo != null)
            {
                AudioController.Instance.Play(AudioController.Instance.damageEnemigo);
                enemigo.RecibirDamage(pistola.Damage);
                gameObject.SetActive(false);
            }
        }
    }
}