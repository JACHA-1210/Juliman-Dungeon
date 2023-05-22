using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallUlti : MonoBehaviour
{
    public float speed = 2f; // Velocidad de la bola de fuego
    public float lifespan = 5f; // Duración de vida de la bola de fuego
    private float timer; // Temporizador para controlar la duración de vida


    // Start is called before the first frame update
    void Start()
    {
        timer = lifespan;

    }

    // Update is called once per frame
    void Update()
    {

        // Mueve la bola de fuego hacia adelante
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // Reduce el temporizador
        timer -= Time.deltaTime;

        // Destruye la bola de fuego si se agota su tiempo de vida
        if (timer <= 0f)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "HitboxZonaBoss" || objecteTocat.tag == "Columna")
        {
            Destroy(gameObject);
        }

        if (objecteTocat.CompareTag("Player"))
        {
            MovimientoGary movimientoGary = objecteTocat.GetComponent<MovimientoGary>();
            if (movimientoGary != null)
            {
                movimientoGary.colisionandoConFireball = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MovimientoGary movimientoGary = collision.GetComponent<MovimientoGary>();
            if (movimientoGary != null)
            {
                movimientoGary.colisionandoConFireball = false;
            }
        }
    }
}
