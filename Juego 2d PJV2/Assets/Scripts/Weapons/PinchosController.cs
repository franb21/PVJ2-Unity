using System.Collections.Generic;
using UnityEngine;

public class PinchosController : MonoBehaviour
{
    private Pinchos pinchos;
    private List<Enemigo> enemigosDentro;
    [SerializeField] private float tiempoVidaPinchos; // futura duracion quizas
    private float cooldown;
    private float tiempoActual;

    public void Inicializar(Pinchos p)
    {
        pinchos = p;
    }
    private void Awake()
    {
        enemigosDentro = new List<Enemigo>();
    }
    private void OnEnable()
    {
        if (pinchos != null)
        {
            transform.localScale = new Vector3(pinchos.Area, pinchos.Area, 1);
            enemigosDentro.Clear();
            cooldown = pinchos.Cooldown / 2f;
            tiempoActual = 0;
        }
    }

    private void Update()
    {
        tiempoActual += Time.deltaTime;
        if (tiempoActual >= tiempoVidaPinchos)
        {
            gameObject.SetActive(false);
            return;
        }

        cooldown -= Time.deltaTime;
        // Los enemigos dentro del arma reciben daño
        if (cooldown <= 0)
        {
            cooldown = pinchos.Cooldown / 2f;
            for (int i = 0; i < enemigosDentro.Count; i++)
            {
                if (enemigosDentro[i] != null)
                    enemigosDentro[i].RecibirDamage(pinchos.Damage);
            }
        }
    }

    // Entra lo agrega a la lista
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemigo"))
        {
            enemigosDentro.Add(collider.GetComponent<Enemigo>());
        }
    }
    // Si sale del area lo elimina de la lista
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemigo"))
        {
            enemigosDentro.Remove(collider.GetComponent<Enemigo>());
        }
    }
}