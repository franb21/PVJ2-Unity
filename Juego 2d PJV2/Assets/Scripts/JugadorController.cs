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
    public Vector2 ultimaDireccion;
    public int experiencia;
    public int LevelPlayer ;
    public int oleada;

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

    void Start()
    {
        ultimaDireccion = new Vector3(0, -1);
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

        if (moverHorizontal != 0 || moverVertical != 0)
        {
            ultimaDireccion = direccion;
        }
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
            //Aca va a el game over
        }
    }
    // Gana experiencia y sube de lv y oleada
    public void GanarExp(int exp)
    {
        experiencia += exp;
        if (experiencia >= LevelPlayer)
        {
            vida += 20 * oleada;
            velocidad += 0.2f * oleada;
            oleada++;
            experiencia -= LevelPlayer;
            LevelPlayer += 10;
        }
        if (oleada == 6)
        {
            // Win
        }
    }
    // Escala para enemigos
    public float Escalar()
    {
        return oleada;
    }
}
