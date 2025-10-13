using System.Collections.Generic;
using UnityEngine;

public class PinchosController : MonoBehaviour
{
    private Pinchos pinchos;
    private List<Enemigo> enemigosDentro;
    [SerializeField] private float tiempoVidaPinchos = 4f; // futura duracion quizas
    private float cooldown;

    void Start()
    {
        pinchos = GameObject.Find("Pinchos").GetComponent<Pinchos>();
        transform.localScale = new Vector3(pinchos.Area, pinchos.Area, 1);
        enemigosDentro = new List<Enemigo>();
        cooldown = pinchos.Cooldown / 2f;
        Destroy(gameObject, tiempoVidaPinchos);
    }
    void Update()
    {
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