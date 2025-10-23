using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZonaElectricaController : MonoBehaviour
{
    private ZonaElectrica zonaElectrica;
    private List<Enemigo> enemigosDentro;
    private float cooldown;
    private Animator miAnimator;

    void Start()
    {
        zonaElectrica = GameObject.Find("Zona Electrica").GetComponent<ZonaElectrica>();
        miAnimator = GetComponent<Animator>();
        transform.localScale = new Vector3(zonaElectrica.Area, zonaElectrica.Area, 1);
        enemigosDentro = new List<Enemigo>();
        cooldown = zonaElectrica.Cooldown;

        //Animacion
        if (miAnimator != null)
        {
            miAnimator.SetTrigger("Activar");
        }
    }

    void Update()
    {
        transform.position = JugadorController.Instance.transform.position;
        transform.localScale = new Vector3(zonaElectrica.Area, zonaElectrica.Area, 1);

        cooldown -= Time.deltaTime;
        // Los enemigos dentro del arma reciben daño
        if (cooldown <= 0)
        {
            cooldown = zonaElectrica.Cooldown;
            for (int i = 0; i < enemigosDentro.Count; i++)
            {
                if (enemigosDentro[i] != null)
                {
                    AudioController.Instance.Play(AudioController.Instance.zonaElectricaDamage);
                    enemigosDentro[i].RecibirDamage(zonaElectrica.Damage);
                }
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
