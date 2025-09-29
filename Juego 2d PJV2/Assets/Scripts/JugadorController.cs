using System.Collections.Generic;
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
    private Vector2 ultimaDireccion;
    public List<int> levels;
    private int experiencia;
    private int levelActual;

    public Vector2 UltimaDireccion { get => ultimaDireccion; }
    public float Vida { get => vida; set => vida = value; }
    public int Experiencia { get => experiencia; }
    public int LevelActual { get => levelActual;}

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
        HUDController.Instance.vidaHUD();
        HUDController.Instance.expHUD();
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
    // Da�o al jugador
    public void RecibirDamage(float damage)
    {
        vida -= damage;
        HUDController.Instance.vidaHUD();
        if (vida <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }
    // Gana experiencia y sube de lv
    public void GanarExp(int exp)
    {
        experiencia += exp;
        HUDController.Instance.expHUD();

        if (experiencia >= levels[levelActual])
        {
            LevelUp();
        }
        //GameManager.Instance.Win();

    }
    // Manejo de subir de lv
    public void LevelUp()
    {
        experiencia -= levels[levelActual];
        levelActual++;
        HUDController.Instance.expHUD();


        // agregar en el hud subir de lv
    }
    public void AumentoDeVida(int aumentoVida)
    {
        vida += aumentoVida;
        HUDController.Instance.vidaHUD();
        //hud lv
    }

    public void AumentoDeVelocidad(float aumentoVelocidad)
    {
        velocidad *= aumentoVelocidad;
        //hud lv
    }
}
