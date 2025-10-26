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
    private Animator miAnimator;
    private SpriteRenderer miSprite;
    private Vector2 direccion;
    private Vector2 ultimaDireccion;
    private int experiencia;
    private int levelActual;
    private List<int> levels;
    private int maxLevel;

    [Header("Armas del jugador")]
    [SerializeField] private List<Weapon> weaponInactivas;
    private List<Weapon> weaponActivas;
    private List<Weapon> weaponMejorables;
    private List<Weapon> weaponMax;

    private bool puedeDamage;
    private float tiempoDamage;

    public Vector2 UltimaDireccion { get => ultimaDireccion; }
    public float Vida { get => vida; }
    public int Experiencia { get => experiencia; }
    public int LevelActual { get => levelActual; }
    public List<Weapon> WeaponActivas { get => weaponActivas; set => weaponActivas = value; }
    public List<Weapon> WeaponMax { get => weaponMax; set => weaponMax = value; }
    public List<int> Levels { get => levels; }

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
        GenerarLevels();
        ultimaDireccion = new Vector2(0, -1);
        HUDController.Instance.VidaHUD();
        HUDController.Instance.ExpHUD();

        WeaponActivas = new List<Weapon>();
        weaponMejorables = new List<Weapon>();
        WeaponMax = new List<Weapon>();

        // Agregar random / futuro menu de seleccion
        AgregarWeapon(MenuManager.armaInicial);
    }
    private void GenerarLevels()
    {
        levels = new List<int>();
        levels.Add(jugadorData.ExpInicial);

        for (int i = 1; i < jugadorData.MaxLevel; i++)
        {
            int expAnterior = levels[i - 1];
            int levelNuevo = expAnterior + (expAnterior / 10) + jugadorData.EscaladoLevels;
            levels.Add(levelNuevo);
        }
    }
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
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

        // Animacion
        float velocidadActual = Mathf.Abs(direccion.x) + Mathf.Abs(direccion.y);
        miAnimator.SetFloat("Velocidad", velocidadActual);

        // Sprite flip
        if (direccion.x < 0)
        {
            miSprite.flipX = true;
        }
        else if (direccion.x > 0)
        {
            miSprite.flipX = false;
        }

        if (tiempoDamage > 0)
        {
            tiempoDamage -= Time.deltaTime;
        }
        else
        {
            puedeDamage = false;
        }
    }
    // Movimiento
    void FixedUpdate()
    {
        if (direccion != Vector2.zero)
        {
            direccion = direccion.normalized;
        }
        miRigidbody2D.MovePosition(miRigidbody2D.position + direccion * (velocidad * Time.fixedDeltaTime));
    }
    // Daño al jugador
    public void RecibirDamage(float damage)
    {
        if (!puedeDamage)
        {
            AudioController.Instance.Play(AudioController.Instance.playerDamage);
            puedeDamage = true;
            tiempoDamage = jugadorData.TiempoEntreDamage;
            vida -= damage;
            PocaVida();
            HUDController.Instance.VidaHUD();
            // Animacion daño
            miAnimator.SetTrigger("Hurt");
            if (vida <= 0)
            {
                vida = 0;
                GameManager.Instance.GameOver();
            }
        }
    }
    // Gana experiencia y sube de lv
    public void GanarExp(int exp)
    {
        experiencia += exp;
        HUDController.Instance.ExpHUD();

        if (experiencia >= Levels[levelActual])
        {
            LevelUp();
        }
        //GameManager.Instance.Win();

    }
    // Manejo de subir de lv
    public void LevelUp()
    {
        AudioController.Instance.Play(AudioController.Instance.levelUp);
        experiencia -= Levels[levelActual];
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
        PocaVida();
        HUDController.Instance.VidaHUD();
        HUDController.Instance.CloseLevelUpPanel();
    }
    //Aumento de velocidad
    public void AumentoDeVelocidad()
    {
        velocidad *= jugadorData.AumentoVelocidad;
        HUDController.Instance.CloseLevelUpPanel();
    }
    // Agregar un nueva arma al jugador
    private void AgregarWeapon(int num)
    {
        WeaponActivas.Add(weaponInactivas[num]);
        weaponInactivas[num].gameObject.SetActive(true);
        weaponInactivas.RemoveAt(num);
    }
    // Activar arma en jugador
    public void ActivarWeapon(Weapon weapon)
    {
        weapon.gameObject.SetActive(true);
        WeaponActivas.Add(weapon);
        weaponInactivas.Remove(weapon);
    }
    // Activar o desactivar el efecto de poca vida
    public void PocaVida()
    {
        if (vida >= 25)
        {
            HUDController.Instance.BloodClose();
        }
        else
        {
            HUDController.Instance.BloodOpen();
        }
    }
}
