using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [Header("Configuracion de enemigo")]
    [SerializeField] private float vida;
    [SerializeField] private float damage;
    [SerializeField] float velocidad;
    private Rigidbody2D miRigidbody2D;
    private Vector2 direccion;

    private void Awake()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
    }

    //Movimiento al jugador
    private void FixedUpdate()
    {
        direccion = (JugadorController.Instance.transform.position - transform.position).normalized;
        miRigidbody2D.MovePosition(miRigidbody2D.position + direccion * (velocidad * Time.fixedDeltaTime));
    }

    //Da�o al enemigo
    public void RecibirDamage(float damage)
    {
        vida -= damage;
        if (vida <= 0)
        {
            Destroy(gameObject);
        }

    }
    //Colision con el jugador
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            JugadorController.Instance.RecibirDamage(damage);
    }

}
