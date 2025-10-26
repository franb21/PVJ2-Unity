using System.Collections;
using UnityEngine;

public class EnemigoBoss : Enemigo
{
    [SerializeField] private Transform puntoDisparo;
    [SerializeField] private Transform puntoDisparoFlip;
    private bool flip;
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
    protected override void FixedUpdate()
    {
        // Si no esta atacando se mueve
        if (!atacando)
        {
            MoverHaciaJugador();

            // Flip
            if (direccion.x < 0)
            {
                miSprite.flipX = true;
                flip = true;
            }
            else if (direccion.x > 0)
            {
                miSprite.flipX = false;
                flip = false;
            }
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

        AudioController.Instance.Play(AudioController.Instance.bossDisparo);

        // Animacion disparr
        if (miAnimator != null)
        {
            miAnimator.SetTrigger("Disparar");
        }
        
        float inicio = Time.time;

        while (Time.time < inicio + enemigoData.DuracionDisparar)
        {
            Vector3 origen;
            if (flip)
            {
                 origen = (puntoDisparoFlip != null) ? puntoDisparoFlip.position : transform.position;
            }
            else
            {
                 origen = (puntoDisparo != null) ? puntoDisparo.position : transform.position;
            }


            GameObject bala = PoolController.Instance.GetPooledObject(enemigoData.PrefabBalaBoss, origen, transform.rotation);

            if (bala != null)
            {
                AudioController.Instance.Play(AudioController.Instance.bossShoot);
                Vector2 dir = (JugadorController.Instance.transform.position - origen).normalized;
                BalaEnemigo balaSpawneada = bala.GetComponent<BalaEnemigo>();
                if (balaSpawneada != null)
                {
                    balaSpawneada.ActivarBala(origen, dir, enemigoData.FuerzaDisparo, enemigoData.TiempoDeVidaBala, damage);
                }
            }
            yield return new WaitForSeconds(enemigoData.TiempoEntreDisparosBoss);
        }

        if (miAnimator != null)
        {
            miAnimator.SetBool("Walk", true);
        }
        
        atacando = true;
    }
    // Movimiento Embestids
    private IEnumerator Embestida()
    {
        AudioController.Instance.Play(AudioController.Instance.bossEmbestida);
        miRigidbody2D.linearVelocity = Vector2.zero;

        if (miAnimator != null)
        {
            miAnimator.SetTrigger("Embestir");
        }

        yield return new WaitForSeconds(enemigoData.TiempoCargaEmbestida);

        Vector2 direccion = (JugadorController.Instance.transform.position - transform.position).normalized;
        miRigidbody2D.linearVelocity = direccion * enemigoData.VelocidadEmbestida;

        yield return new WaitForSeconds(enemigoData.TiempoCargaEmbestida);

        miRigidbody2D.linearVelocity = Vector2.zero;

        if (miAnimator != null)
        {
            miAnimator.SetBool("Walk", true);
        }
        
        atacando = true;
    }
    // Movimiento Invocar
    private IEnumerator InvocarEnemigos()
    {
        atacando = false;
        miRigidbody2D.linearVelocity = Vector2.zero;

        AudioController.Instance.Play(AudioController.Instance.bossInvocacion);
        if (miAnimator != null)
        {
            miAnimator.SetTrigger("Invocar");
        }
        
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

        if (miAnimator != null)
        {
            miAnimator.SetBool("Walk", true);
        }
        
        atacando = true;
    }
    public override void RecibirDamage(float damage)
    {
        vida -= damage;
        if (enemigoData.EfectoDamage != null)
        {
            PoolController.Instance.GetPooledObject(enemigoData.EfectoDamage, transform.position, Quaternion.identity);
        }
        if (vida <= 0)
        {
            if (enemigoData.ParticulasMuerte != null)
            {
                PoolController.Instance.GetPooledObject(enemigoData.ParticulasMuerte, transform.position, Quaternion.identity);
            }
            GameManager.Instance.Win();
            Spawn.Instance.Kill();
            gameObject.SetActive(false); // vuelve al pool cuando se elimina
            JugadorController.Instance.GanarExp(exp);
            HUDController.Instance.ActualizarKills();
        }

    }
}
