using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update

    private float _vel = 0f; // Velocidad de movimiento del zombie
    private Transform Gary; // Referencia al jugador
    private bool JugadorCerca = false; // Indicador de seguimiento activo
    private SpriteRenderer spriteBoss;


    private Animator anim;

    private bool GaryVivo = true;



    private void Start()
    {
        Gary = GameObject.FindGameObjectWithTag("Player").transform;
        spriteBoss = GameObject.Find("BossAnimacion").GetComponent<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
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
                spriteBoss.flipX = true; // Invertir la escala horizontalmente
            }
            else if (direction.x > 0)
            {
                spriteBoss.flipX = false; // Mantener la escala original
            }
        }
        else
        {
            anim.SetTrigger("Quieto");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            JugadorCerca = true;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            JugadorCerca = false;
        }
    }




}
