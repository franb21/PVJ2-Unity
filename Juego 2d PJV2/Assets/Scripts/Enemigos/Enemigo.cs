using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [Header("Config por ScriptableObject")]
    [SerializeField] protected EnemigoStatsSO enemigoData;

    [SerializeField] protected GameObject particulasMuerte;

    protected float vida;
    protected float damage;
    protected float velocidad;
    protected int exp;
    protected Rigidbody2D miRigidbody2D;
    protected Vector2 direccion;
    protected Animator miAnimator;
    protected SpriteRenderer miSprite;

    protected virtual void Awake()
    {
        vida = enemigoData.Vida;
        damage = enemigoData.Damage;
        velocidad = enemigoData.Velocidad;
        exp = enemigoData.Exp;
    }

    protected virtual void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
    }

    protected virtual void FixedUpdate()
    {
        MoverHaciaJugador();
    }

    //Movimiento al jugador
    protected void MoverHaciaJugador()
    {
        direccion = (JugadorController.Instance.transform.position - transform.position).normalized;
        miRigidbody2D.MovePosition(miRigidbody2D.position + direccion * (velocidad * Time.fixedDeltaTime));

        if (miAnimator != null)
        {
            miAnimator.SetBool("Walk", true);
        }

        if (direccion.x < 0)
        {
            miSprite.flipX = true;
        }
        else if (direccion.x > 0)
        {
            miSprite.flipX = false;
        }
    }

    //Daño al enemigo
    public virtual void RecibirDamage(float damage)
    {
        vida -= damage;
        if (vida <= 0)
        {
            if (particulasMuerte != null)
            {
                PoolController.Instance.GetPooledObject(particulasMuerte, transform.position, Quaternion.identity);
            }
            Spawn.Instance.Kill();
            gameObject.SetActive(false); // vuelve al pool cuando se elimina
            JugadorController.Instance.GanarExp(exp);
            HUDController.Instance.ActualizarKills();
        }

    }
    //Colision con el jugador
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            JugadorController.Instance.RecibirDamage(damage);
        }

    }
    //Ajustar stats para oleadas
    public void AjustarStats(float multVida, float multDamage, float multVel)
    {
        ReiniciarStats();
        vida *= multVida;
        damage *= multDamage;
        velocidad *= multVel;
    }
    //Reinicia las stats
    public void ReiniciarStats()
    {
        vida = enemigoData.Vida;
        damage = enemigoData.Damage;
        velocidad = enemigoData.Velocidad;
    }
}
