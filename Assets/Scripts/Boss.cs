using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update

    private float _vel = 1f; // Velocidad de movimiento del zombie
    private Transform Gary; // Referencia al jugador
    public Sprite Boss_11; // Sprite del enemigo final cuando está quieto
    public Sprite Boss_8;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        Gary = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula la dirección hacia el jugador
        Vector3 direccion = Gary.position - transform.position;
        direccion.Normalize();

        if (direccion.magnitude < 3f) // Ajusta el valor 5f según la distancia deseada para que el enemigo comience a moverse
        {
            spriteRenderer.sprite = Boss_8;
            transform.position += direccion * _vel * Time.deltaTime;
        }
        else
        {
            spriteRenderer.sprite = Boss_11;
        }


    }


}
