using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadasHitboxPersonaje : MonoBehaviour
{

    public bool colisionandoConZombie = false;

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
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
           

            colisionandoConZombie = false;
        }
    }
}
