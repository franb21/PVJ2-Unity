using System.Collections;
using UnityEngine;

public class EnemigoEnjambre : Enemigo
{
    private bool direccionInicial = false;
    private float tiempoActual = 0;

    private void OnEnable()
    {
        // Reiniciar variables cada vez que se activa desde el pool
        tiempoActual = 0;
        direccionInicial = true;

        if (JugadorController.Instance != null)
        {
            direccion = (JugadorController.Instance.transform.position - transform.position).normalized;
        }
        else
        {
            direccionInicial = false; // no mover hasta que exista jugador
        }
    }
    private void FixedUpdate()
    {
        if (!direccionInicial) return;

        // Movimiento hacia el jugador sin parar
        miRigidbody2D.MovePosition(miRigidbody2D.position + direccion * (velocidad * Time.fixedDeltaTime));
    }
    private void Update()
    {
        if (!direccionInicial) return;

        tiempoActual += Time.deltaTime;
        if (tiempoActual >= enemigoData.TiempoDeVidaEnemigo)
        {
            gameObject.SetActive(false); // vuelve al pool
        }
    }
}