using UnityEngine;

public class Pinchos : Weapon
{
    private float tiempoDisparo = 0f;

    void Update()
    {
        tiempoDisparo -= Time.deltaTime;

        if (tiempoDisparo <= 0)
        {
            tiempoDisparo = Cooldown;

            for (int i = 0; i < Cantidad; i++)
            {
                Vector3 pos = JugadorController.Instance.transform.position;
                Vector3 spawnPos;
                if (i == 0)
                {
                    float offsetX = Random.Range(-0.5f, 0.5f);
                    float offsetY = Random.Range(-0.5f, 0.5f);
                    spawnPos = pos + new Vector3(offsetX, offsetY, 0);
                }
                else
                {
                    float offsetX = Random.Range(-1.5f, 1.5f);
                    float offsetY = Random.Range(-1.5f, 1.5f);
                    spawnPos = pos + new Vector3(offsetX, offsetY, 0);
                }
                GameObject pinchos = PoolController.Instance.GetPooledObject(WeaponData.PrefabWeapon, spawnPos, transform.rotation);
                PinchosController pinchoSpaweneado = pinchos.GetComponent<PinchosController>();
                pinchoSpaweneado.Inicializar(GetComponent<Pinchos>());
            }
        }
    }
}
