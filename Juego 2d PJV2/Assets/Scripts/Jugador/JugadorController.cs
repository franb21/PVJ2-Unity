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

    [Header("Armas del jugador")]
    [SerializeField] private List<Weapon> weaponInactivas;
    private List<Weapon> weaponActivas;
    private List<Weapon> weaponMejorables;
    private List<Weapon> weaponMax;

    public Vector2 UltimaDireccion { get => ultimaDireccion; }
    public float Vida { get => vida; }
    public int Experiencia { get => experiencia; }
    public int LevelActual { get => levelActual; }
    public int[] Levels { get => jugadorData.Levels; }
    public List<Weapon> WeaponActivas { get => weaponActivas; set => weaponActivas = value; }
    public List<Weapon> WeaponMax { get => weaponMax; set => weaponMax = value; }

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
        HUDController.Instance.VidaHUD();
        HUDController.Instance.ExpHUD();

        WeaponActivas = new List<Weapon>();
        weaponMejorables = new List<Weapon>();
        WeaponMax = new List<Weapon>();
        // Agregar random / futuro menu de seleccion
        AgregarWeapon(0);
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
        HUDController.Instance.VidaHUD();
        if (vida <= 0)
        {
            vida = 0;
            GameManager.Instance.GameOver();
        }
    }
    // Gana experiencia y sube de lv
    public void GanarExp(int exp)
    {
        experiencia += exp;
        HUDController.Instance.ExpHUD();

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
        HUDController.Instance.ExpHUD();

        weaponMejorables.Clear();
        if (WeaponActivas.Count > 0)
        {
            weaponMejorables.AddRange(WeaponActivas);
        }
        if (weaponInactivas.Count > 0)
        {
            weaponMejorables.AddRange(weaponInactivas);
        }
        for (int i = 0; i < HUDController.Instance.levelUpButtons.Length; i++)
        {
            if (i < weaponMejorables.Count)
            {
                HUDController.Instance.levelUpButtons[i].AsignarButton(weaponMejorables[i]);
                HUDController.Instance.levelUpButtons[i].gameObject.SetActive(true);
            }
            else
            {
                HUDController.Instance.levelUpButtons[i].gameObject.SetActive(false);
            }
        }
        HUDController.Instance.OpenLevelUpPanel();
    }
    //Aumento de vida
    public void AumentoDeVida()
    {
        vida += jugadorData.AumentoVida;
        HUDController.Instance.VidaHUD();
        HUDController.Instance.CloseLevelUpPanel();
    }
    //Aumento de velocidad
    public void AumentoDeVelocidad()
    {
        velocidad *= jugadorData.AumentoVelocidad;
        HUDController.Instance.CloseLevelUpPanel();
    }
    private void AgregarWeapon(int num)
    {
        WeaponActivas.Add(weaponInactivas[num]);
        weaponInactivas[num].gameObject.SetActive(true);
        weaponInactivas.RemoveAt(num);
    }

    public void ActivarWeapon(Weapon weapon)
    {
        weapon.gameObject.SetActive(true);
        WeaponActivas.Add(weapon);
        weaponInactivas.Remove(weapon);
    }
}
