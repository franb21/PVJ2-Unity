using System.Collections;
using UnityEngine;

public class EnemigoBoss : Enemigo
{
    [SerializeField] private Transform puntoDisparo;
    private int estadoActual;
    private const int DISPARAR = 0;
    private const int EMBESTIR = 1;
    private const int INVOCAR = 2;
    private bool atacando = false;

    private void Start()
    {
        // Empieza la corrutina
        estadoActual = Random.Range(0, 3);
        StartCoroutine(ComportamientoJefe());
    }
    private void FixedUpdate()
    {
        // Si no esta atacando se mueve
        if (!atacando)
        {
            direccion = (JugadorController.Instance.transform.position - transform.position).normalized;
            miRigidbody2D.MovePosition(miRigidbody2D.position + direccion * (velocidad * Time.fixedDeltaTime));
        }
    }
    private IEnumerator ComportamientoJefe()
    {
        while (true)
        {
            switch (estadoActual)
            {
                case DISPARAR:
                    yield return StartCoroutine(Disparar());
                    break;
                case EMBESTIR:
                    yield return StartCoroutine(Embestida());
                    break;
                case INVOCAR:
                    yield return StartCoroutine(InvocarEnemigos());
                    break;
            }
            yield return new WaitForSeconds(enemigoData.TiempoEntreEstados);
            estadoActual = Random.Range(0, 3);
        }
    }
    // Movimiento Disparar
    private IEnumerator Disparar()
    {
        atacando = false;
        float inicio = Time.time;

        while (Time.time < inicio + enemigoData.DuracionDisparar)
        {
            Vector3 origen = (puntoDisparo != null) ? puntoDisparo.position : transform.position;

            GameObject bala = PoolController.Instance.GetPooledObject(enemigoData.PrefabBalaBoss, origen, transform.rotation);

            if (bala != null)
            {
                Vector2 dir = (JugadorController.Instance.transform.position - origen).normalized;
                BalaEnemigo balaSpawneada = bala.GetComponent<BalaEnemigo>();
                if (balaSpawneada != null)
                {
                    balaSpawneada.ActivarBala(origen, dir, enemigoData.FuerzaDisparo, enemigoData.TiempoDeVidaBala, damage);
                }
            }
            yield return new WaitForSeconds(enemigoData.TiempoEntreDisparosBoss);
        }
        atacando = true;
    }
    // Movimiento Embestids
    private IEnumerator Embestida()
    {
        miRigidbody2D.linearVelocity = Vector2.zero;

        yield return new WaitForSeconds(enemigoData.TiempoCargaEmbestida);

        Vector2 direccion = (JugadorController.Instance.transform.position - transform.position).normalized;
        miRigidbody2D.linearVelocity = direccion * enemigoData.VelocidadEmbestida;

        yield return new WaitForSeconds(enemigoData.TiempoCargaEmbestida);

        miRigidbody2D.linearVelocity = Vector2.zero;
        atacando = true;
    }
    // Movimiento Invocar
    private IEnumerator InvocarEnemigos()
    {
        atacando = false;
        miRigidbody2D.linearVelocity = Vector2.zero;

        yield return new WaitForSeconds(enemigoData.TiempoInvocacion);

        Vector2 centro = JugadorController.Instance.transform.position;

        for (int i = 0; i < enemigoData.CantidadEnemigosInvocados; i++)
        {
            float angulo = (360f / enemigoData.CantidadEnemigosInvocados) * i;
            Vector2 offset = new Vector2(Mathf.Cos(angulo), Mathf.Sin(angulo)) * enemigoData.RadioInvocacion;
            Vector2 spawnPos = centro + offset;

            GameObject enemigoInvocado = PoolController.Instance.GetPooledObject(enemigoData.PrefabEnemgiosInvocacion, spawnPos, transform.rotation);
        }

        yield return new WaitForSeconds(enemigoData.TiempoPostInvocacion);
        atacando = true;
    }
}
