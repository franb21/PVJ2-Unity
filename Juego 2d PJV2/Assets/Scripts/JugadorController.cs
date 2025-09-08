using UnityEngine;

public class JugadorController : MonoBehaviour
{
    public static JugadorController Instance;
    [Header("Configuracion Jugador")]
    [SerializeField] private float velocidad;
    [SerializeField] private float vida;
    private float moverHorizontal;
    private float moverVertical;
    private Vector2 direccion;
    private Rigidbody2D miRigidbody2D;
    // Singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
        moverVertical = Input.GetAxis("Vertical");
        direccion = new Vector2(moverHorizontal, moverVertical);
    }
    // Movimiento
    void FixedUpdate()
    {
        miRigidbody2D.MovePosition(miRigidbody2D.position + direccion * (velocidad * Time.fixedDeltaTime));
    }
    // Daño al jugador
    public void RecibirDamage(float damage)
    {
        vida -= damage;
        if (vida <= 0)
        {
        }
    }
}
