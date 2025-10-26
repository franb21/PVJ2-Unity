using UnityEngine;

public class EfectoDamage : MonoBehaviour
{
    [SerializeField]private float tiempoVida;
    private float tiempoActual;

    void OnEnable()
    {
        tiempoActual = tiempoVida;
    }

    void Update()
    {
        tiempoActual -= Time.deltaTime;
        if (tiempoActual <= 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
