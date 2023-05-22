using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadasHitboxPersonaje : MonoBehaviour
{

    public bool colisionandoConZombie = false;
    public bool colisionandoConBoss = false;

    public GameObject collisionGlobal;


    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {

            collisionGlobal = collision.gameObject;

            colisionandoConZombie = true;
            
        }

        if (collision.CompareTag("Boss"))
        {

            colisionandoConBoss = true;

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
           

            colisionandoConZombie = false;
        }

        if (collision.CompareTag("Boss"))
        {

            colisionandoConBoss = false;

        }
    }
}
