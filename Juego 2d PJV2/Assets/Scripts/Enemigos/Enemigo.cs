using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [Header("Config por ScriptableObject")]
    [SerializeField] protected EnemigoStatsSO enemigoData;

    protected float vida;
    protected float damage;
    protected float velocidad;
    protected int exp;
    protected Rigidbody2D miRigidbody2D;
    protected Vector2 direccion;

    protected virtual void Awake()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        vida = enemigoData.Vida;
        damage = enemigoData.Damage;
        velocidad = enemigoData.Velocidad;
        exp = enemigoData.Exp;
    }

    //Movimiento al jugador
    private void FixedUpdate()
    {
        direccion = (JugadorController.Instance.transform.position - transform.position).normalized;
        miRigidbody2D.MovePosition(miRigidbody2D.position + direccion * (velocidad * Time.fixedDeltaTime));
    }

    //Daño al enemigo
    public void RecibirDamage(float damage)
    {
        vida -= damage;
        if (vida <= 0)
        {
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
            JugadorController.Instance.RecibirDamage(damage);
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
