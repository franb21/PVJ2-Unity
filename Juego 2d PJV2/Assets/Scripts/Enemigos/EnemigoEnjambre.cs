using System.Collections;
using UnityEngine;

public class EnemigoEnjambre : Enemigo
{
    private float tiempoActual = 0;

    protected override void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();

        // Reiniciar variables cada vez que se activa desde el pool
        tiempoActual = 0;

        if (JugadorController.Instance != null)
        {
            direccion = (JugadorController.Instance.transform.position - transform.position).normalized;
        }
    }
    protected override void FixedUpdate()
    {
        if (JugadorController.Instance == null) return;

        // Movimiento hacia el jugador sin parar
        miRigidbody2D.MovePosition(miRigidbody2D.position + direccion * (velocidad * Time.fixedDeltaTime));

        if (direccion.x < 0)
        {
            miSprite.flipX = true;
        }
        else if (direccion.x > 0)
        {
            miSprite.flipX = false;
        }
    }
    private void Update()
    {
        tiempoActual += Time.deltaTime;
        if (tiempoActual >= enemigoData.TiempoDeVidaEnemigo)
        {
            gameObject.SetActive(false); // vuelve al pool
        }
    }
}