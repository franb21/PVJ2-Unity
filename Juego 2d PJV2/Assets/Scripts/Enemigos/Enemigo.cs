using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [Header("Config por ScriptableObject")]
    [SerializeField] private EnemigoStatsSO enemigoData;

    private float vida;
    private float damage;
    private float velocidad;
    private int exp;
    private Rigidbody2D miRigidbody2D;
    private Vector2 direccion;

    private void Awake()
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
            Destroy(gameObject);
            JugadorController.Instance.GanarExp(exp);
        }

    }
    //Colision con el jugador
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            JugadorController.Instance.RecibirDamage(damage);
    }

}
