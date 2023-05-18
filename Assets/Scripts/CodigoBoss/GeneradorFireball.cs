using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorFireball : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject _Fireball;
    private bool PlayerEsta;
    GameObject player;
    public float shootingRange = 3f;


    void Start()
    {
        InvokeRepeating("CreaProjectil", 0.2f, 5f);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance < shootingRange)
            {
                CreaProjectil();
            }
        }
    }

    private void CreaProjectil()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            GameObject fireball = Instantiate(_Fireball);
            fireball.transform.position = transform.position;

            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();

            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
            rb.AddForce(direction * 500f); // Ajusta la fuerza según lo deseado
        }
    }
}
