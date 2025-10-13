using System.Collections;
using UnityEngine;

public class EnemigoEnjambre : Enemigo
{
    private bool direccionInicial = false;

    private void Start()
    {
        // Direccion hacia el jugador cuando spawnea
        direccion = (JugadorController.Instance.transform.position - transform.position).normalized;
        direccionInicial = true;
        Destroy(gameObject, enemigoData.TiempoDeVidaEnemigo);
    }
    private void FixedUpdate()
    {
        if (!direccionInicial) return;

        // Movimiento hacia el jugador sin parar
        miRigidbody2D.MovePosition(miRigidbody2D.position + direccion * (velocidad * Time.fixedDeltaTime));
    }
}