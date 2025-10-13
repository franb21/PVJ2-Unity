using UnityEngine;

public class ZonaElectrica : Weapon
{
    private GameObject zonaInstanciada;

    // Instancia una vez
    void Start()
    {
        if (zonaInstanciada == null && WeaponData.PrefabWeapon != null)
        {
            zonaInstanciada = Instantiate(WeaponData.PrefabWeapon, transform.position, transform.rotation);
        }
    }
}
