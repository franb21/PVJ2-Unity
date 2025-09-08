using UnityEngine;

public class Pistola : MonoBehaviour
{
    [SerializeField] private GameObject pistolaControllerPrefab;
    public float cooldown = 0.5f;
    public float damage = 10f;
    public float speed = 10f;
    public bool penetracion = false;
    private float tiempoDisparo = 0f;

    void Update()
    {
        tiempoDisparo += Time.deltaTime;

        if (tiempoDisparo >= cooldown)
        {
            // Instancia el proyectil en la posicion
            Instantiate(pistolaControllerPrefab, transform.position, transform.rotation);
            tiempoDisparo = 0f;
        }
    }
}