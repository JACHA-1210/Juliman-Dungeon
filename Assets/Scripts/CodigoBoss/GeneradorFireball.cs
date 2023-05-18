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
    public float shootingDelay = 10f;
    private bool isInvoking = false;
    public int burstCount = 10;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(ShootBurstWithDelay());
    }

    private IEnumerator ShootBurstWithDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootingDelay);

            for (int i = 0; i < burstCount; i++)
            {
                CreaProjectil();
                yield return new WaitForSeconds(0.1f); // Espacio de tiempo entre cada disparo de la ráfaga
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
