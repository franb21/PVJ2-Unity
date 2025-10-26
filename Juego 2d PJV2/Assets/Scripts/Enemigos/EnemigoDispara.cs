using System.Collections;
using UnityEngine;

public class EnemigoDispara : Enemigo
{
    private bool disparando = false;

    protected override void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
        StartCoroutine(ComportamientoEnemigo());
    }

    protected override void FixedUpdate()
    {
        // Si no dispara se mueve
        if (!disparando)
        {
            // Moverse
            miAnimator.SetBool("Walk", true);
            MoverHaciaJugador();
        }
        else
        {
            // Animacion quieta
            miAnimator.SetBool("Walk", false);
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

            // Animacion de disparo
            miAnimator.SetTrigger("Attack");

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
                AudioController.Instance.Play(AudioController.Instance.enemigoDisparo);
                balaSpawneada.ActivarBala(transform.position, dir, enemigoData.FuerzaDisparo, enemigoData.TiempoDeVidaBala, damage);

            }
        }
    }
    void OnDisable()
    {
        StopAllCoroutines();
        disparando = false;
    }
}