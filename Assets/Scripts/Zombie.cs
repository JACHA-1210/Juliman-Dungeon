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

    private EspadasHitboxPersonaje espadasHitboxPersonaje;

    private bool controladorEspada = true;

    private bool usandoEspada = false;

    private bool zombieDestruido = false;

    private void Start()
    {
        Gary = GameObject.FindGameObjectWithTag("Player").transform;
        spriteZombie = GameObject.Find("AnimadorZombie").GetComponent<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        espadasHitboxPersonaje = GameObject.FindObjectOfType<EspadasHitboxPersonaje>();

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

        //Espadas

        if (GameObject.FindGameObjectWithTag("Enemic") != null)
        {
            if (Input.GetMouseButton(0) && !GameObject.Find("Gary").GetComponent<MovimientoGary>().siendoEmpujado)
            {
                usandoEspada = true;
                Invoke("UsandoEspada", 0.8f);
            }

            if (GameObject.Find("EspadasHitboxPersonaje").GetComponent<EspadasHitboxPersonaje>().colisionandoConZombie && usandoEspada && controladorEspada)
            {
                Invoke("EspadaTocaZombie", 0.1f);
            }
        }

    }

    public void EspadaTocaZombie()
    {
            
            DestroyZombie();
            controladorEspada = false;
            Invoke("CambiarControladorEspada", 0.8f);
        
    }


    public void CambiarControladorEspada()
    {
        controladorEspada = true;
    }

    public void UsandoEspada()
    {
        usandoEspada = false;
    }

    public void DestroyZombie()
    {
        if (!zombieDestruido)
        {
            zombieDestruido = true;
            Destroy(gameObject);
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
