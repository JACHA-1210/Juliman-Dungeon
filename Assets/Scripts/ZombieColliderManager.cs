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
            // Aquí puedes manejar la lógica de interacción entre el jugador y el Zombie
            // Por ejemplo, puedes hacer que el jugador pierda vida o realizar cualquier otra acción necesaria
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // El jugador ha entrado en el collider del Zombie
            // Aquí puedes manejar la lógica de interacción inicial entre el jugador y el Zombie
            // Por ejemplo, puedes hacer que el Zombie comience a seguir al jugador
        }
    }
}
