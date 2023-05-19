using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballC : MonoBehaviour
{
    public GameObject _Fireball;
    public int fireballCount = 10;
    public float fireballSpeed = 5f;
    public float fireballRadius = 5f;
    public float generationDelay = 10f;
    public float fireballForce = 5f;
    public float detectionRadius = 10f; // Distancia para detectar al jugador

    private Transform playerTransform;
    private bool canGenerateFireballs = false;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Invoke("StartGeneratingFireballs", 3f);
    }

    private void Update()
    {
        // Calcula la distancia entre el Boss y el jugador
        float distance = Vector2.Distance(transform.position, playerTransform.position);

        if (distance < detectionRadius)
        {
            canGenerateFireballs = true;
        }
        else
        {
            canGenerateFireballs = false;
        }
    }

    private void StartGeneratingFireballs()
    {
        InvokeRepeating("GenerateFireballCircle", generationDelay, generationDelay);
    }

    private void GenerateFireballCircle()
    {

        if (!canGenerateFireballs)
        {
            return;
        }

        float angleStep = 360f / fireballCount;
        Vector3 bossPosition = transform.position;

        for (int i = 0; i < fireballCount; i++)
        {
            float angle = i * angleStep;
            Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
            GameObject fireball = Instantiate(_Fireball, bossPosition, rotation);
            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0f; // Desactivar la gravedad
            rb.velocity = fireballSpeed * fireball.transform.right;
        }
    }
}

