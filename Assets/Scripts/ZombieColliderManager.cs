using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieColliderManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // El jugador ha colisionado con el Zombie
            // Aqu� puedes manejar la l�gica de interacci�n entre el jugador y el Zombie
            // Por ejemplo, puedes hacer que el jugador pierda vida o realizar cualquier otra acci�n necesaria
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // El jugador ha entrado en el collider del Zombie
            // Aqu� puedes manejar la l�gica de interacci�n inicial entre el jugador y el Zombie
            // Por ejemplo, puedes hacer que el Zombie comience a seguir al jugador
        }
    }
}
