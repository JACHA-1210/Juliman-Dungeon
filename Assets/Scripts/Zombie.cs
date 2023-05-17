using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private float _vel = 1f; // Velocidad de movimiento del zombie
    private Transform Gary; // Referencia al jugador
    private bool JugadorCerca = false; // Indicador de seguimiento activo

    private SpriteRenderer spriteZombie;

    private Animator anim;

    private bool GaryVivo = true;

    private void Start()
    {
        Gary = GameObject.FindGameObjectWithTag("Player").transform;
        spriteZombie = GameObject.Find("AnimadorZombie").GetComponent<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        
    }

    private void Update()
    {
        GaryVivo = GameObject.Find("Gary").GetComponent<MovimientoGary>().GaryVivo;

        if (JugadorCerca && Gary != null && GaryVivo)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direction = Gary.position - transform.position;
            direction.Normalize();

            // Mueve el zombie hacia el jugador
            transform.position += direction * _vel * Time.deltaTime;

            anim.SetTrigger("Moverse");

            // Girar el objeto hacia la izquierda o derecha
            if (direction.x < 0)
            {
                spriteZombie.flipX = true; // Invertir la escala horizontalmente
            }
            else if (direction.x > 0)
            {
                spriteZombie.flipX = false; // Mantener la escala original
            }
        } else
        {
            anim.SetTrigger("Quieto");
        }
        
    }

    public void DestroyZombie()
    {
        Destroy(gameObject);
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
