using System;
using UnityEngine;

public class Pistola : Weapon
{
    private float tiempoDisparo = 0f;
    void Update()
    {
        tiempoDisparo -= Time.deltaTime;

        if (tiempoDisparo <= 0)
        {
            tiempoDisparo = Cooldown;
            // Instancia el proyectil en la posicion y segun la cantidad aumenta
            Vector2 dir = JugadorController.Instance.UltimaDireccion.normalized;
            for (int i = 0; i < Cantidad; i++)
            {
                Vector3 offset = dir * (i * -0.5f);
                Instantiate(WeaponData.PrefabWeapon, transform.position + offset, transform.rotation);
            }
        }
    }
}