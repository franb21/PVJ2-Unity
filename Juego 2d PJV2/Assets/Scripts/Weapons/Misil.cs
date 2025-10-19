using UnityEngine;

public class Misil : Weapon
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
                GameObject misil = PoolController.Instance.GetPooledObject(WeaponData.PrefabWeapon, pos, transform.rotation);
                MisilController misilSpawneado = misil.GetComponent<MisilController>();
                misilSpawneado.Inicializar(GetComponent<Misil>());
            }
        }
    }
}