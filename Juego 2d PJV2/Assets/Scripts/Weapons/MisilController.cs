using UnityEngine;

public class MisilController : MonoBehaviour
{
    private Misil misil;
    private Rigidbody2D rb;
    private float vidaRestante;
    [SerializeField] private float velocidad;
    [SerializeField] private float tiempoVida;
    private Vector2 direccion;
    private Animator miAnimator;

    public void Inicializar(Misil m)
    {
        misil = m;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        // Evita errores
        if (misil != null)
        {
            AudioController.Instance.Play(AudioController.Instance.misil);
            //Animacion
            if (miAnimator != null)
            {
                miAnimator.SetTrigger("Activar");
            }

            vidaRestante = tiempoVida;

            // Busca un enemigo y calcula la direccion hacia el
            Transform objetivo = BuscarEnemigo();
            if (objetivo != null)
            {
                direccion = ((Vector2)objetivo.position - rb.position).normalized;
            }
            else
            {
                direccion = JugadorController.Instance.UltimaDireccion.normalized;
            }
            rb.linearVelocity = direccion * velocidad;
        }
    }
    private void Update()
    {
        vidaRestante -= Time.deltaTime;
        if (vidaRestante <= 0)
        {
            gameObject.SetActive(false);
        }
        transform.Rotate(Vector3.forward * 360f * Time.deltaTime);
    }
    // Busca un enemigo aleatorio
    private Transform BuscarEnemigo()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        if (enemigos.Length == 0)
        {
            return null;
        }
        int indice = Random.Range(0, enemigos.Length);

        return enemigos[indice].transform;
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
                enemigo.RecibirDamage(misil.Damage);
                gameObject.SetActive(false);
            }
        }
    }
}