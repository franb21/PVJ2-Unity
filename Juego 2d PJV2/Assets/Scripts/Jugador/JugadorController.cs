using System.Collections.Generic;
using UnityEngine;

public class JugadorController : MonoBehaviour
{
    public static JugadorController Instance;

    [Header("Config por ScriptableObject")]
    [SerializeField] private JugadorStatsSO jugadorData;

    private float vida;
    private float velocidad;
    private Rigidbody2D miRigidbody2D;
    private Vector2 direccion;
    private Vector2 ultimaDireccion;
    private int experiencia;
    private int levelActual;
    [SerializeField] private Weapon weapon;

    public Vector2 UltimaDireccion { get => ultimaDireccion; }
    public float Vida { get => vida; }
    public int Experiencia { get => experiencia; }
    public int LevelActual { get => levelActual; }
    public int[] Levels { get => jugadorData.Levels; }

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
        vida = jugadorData.Vida;
        velocidad = jugadorData.Velocidad;

        ultimaDireccion = new Vector2(0, -1);
        HUDController.Instance.vidaHUD();
        HUDController.Instance.expHUD();
    }

    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moverHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");
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

        if (experiencia >= jugadorData.Levels[levelActual])
        {
            LevelUp();
        }
        //GameManager.Instance.Win();

    }
    // Manejo de subir de lv
    public void LevelUp()
    {
        experiencia -= jugadorData.Levels[levelActual];
        levelActual++;
        HUDController.Instance.expHUD();
        HUDController.Instance.levelUpButton.AsignarButton(weapon);
        HUDController.Instance.levelUpButton.gameObject.SetActive(true);
        HUDController.Instance.OpenLevelUpPanel();
    }
    //Aumento de vida
    public void AumentoDeVida()
    {
        vida += jugadorData.AumentoVida;
        HUDController.Instance.vidaHUD();
        HUDController.Instance.CloseLevelUpPanel();
    }
    //Aumento de velocidad
    public void AumentoDeVelocidad()
    {
        velocidad *= jugadorData.AumentoVelocidad;
        HUDController.Instance.CloseLevelUpPanel();
    }
}
