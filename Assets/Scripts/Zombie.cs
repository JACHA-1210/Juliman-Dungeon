using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private float _vel = 1.5f; // Velocidad de movimiento del zombie
    private Transform Gary; // Referencia al jugador
    private bool JugadorCerca = false; // Indicador de seguimiento activo

    private void Start()
    {
        Gary = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (JugadorCerca && Gary != null)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direction = Gary.position - transform.position;
            direction.Normalize();

            // Mueve el zombie hacia el jugador
            transform.position += direction * _vel * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // El jugador ha entrado en el rango del zombie
            // Inicia el seguimiento del jugador
            JugadorCerca = true;
        }
    }

}
