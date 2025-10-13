using System.Collections;
using UnityEngine;

public class EnemigoDispara : Enemigo
{
    private bool disparando = false;

    void Start()
    {
        // Empieza la corrutina
        StartCoroutine(ComportamientoEnemigo());
    }
    private void FixedUpdate()
    {
        // Si no dispara se mueve
        if (!disparando)
        {
            direccion = (JugadorController.Instance.transform.position - transform.position).normalized;
            miRigidbody2D.MovePosition(miRigidbody2D.position + direccion * (velocidad * Time.fixedDeltaTime));
        }
    }
    IEnumerator ComportamientoEnemigo()
    {
        while (true)
        {
            // Persigue un rato antes de disparar
            yield return new WaitForSeconds(enemigoData.TiempoEntreDisparos);

            // Se para y dispara
            disparando = true;
            yield return new WaitForSeconds(enemigoData.TiempoQuieto);
            Disparar();

            // Espara un poco y vuelve a moverse
            yield return new WaitForSeconds(enemigoData.TiempoQuieto);
            disparando = false;
        }
    }
    // Disparar bala del enemigo
    private void Disparar()
    {
        if (enemigoData.BalaPrefab == null) return;
        GameObject bala = PoolController.Instance.GetPooledObject(enemigoData.BalaPrefab, transform.position, transform.rotation);

        if (bala != null)
        {
            Vector2 dir = (JugadorController.Instance.transform.position - transform.position).normalized;

            BalaEnemigo balaSpawneada = bala.GetComponent<BalaEnemigo>();
            if (balaSpawneada != null)
            {
                balaSpawneada.ActivarBala(transform.position, dir, enemigoData.FuerzaDisparo, enemigoData.TiempoDeVidaBala, damage);

            }
        }
    }
}