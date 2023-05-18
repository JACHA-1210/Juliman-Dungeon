using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadasHitboxPersonaje : MonoBehaviour
{

    public GameObject espadaHitboxIzquierda;
    public GameObject espadaHitboxDerecha;

    public bool colisionandoConZombie = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ColZombie")
        {
            GameObject zombie = collision.gameObject;
            Destroy(zombie);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ColZombie")
        {
            colisionandoConZombie = false;
        }
    }
}
