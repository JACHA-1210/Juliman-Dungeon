using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorFireball : MonoBehaviour
{
    public GameObject _Fireball;
    public float shootingRange = 10f;
    public float shootingDelay = 10f;
    public int burstCount = 10;
    private GameObject player;
    private bool isShooting = false;

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(ShootBurstWithDelay());
    }

    private IEnumerator ShootBurstWithDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootingDelay);

            if (player != null && IsPlayerInRange())
            {
                isShooting = true;

                for (int i = 0; i < burstCount; i++)
                {
                    CreaProjectil();
                    yield return new WaitForSeconds(0.1f);
                }

                isShooting = false;
            }
        }
    }

    private bool IsPlayerInRange()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance < shootingRange);
        return distance < shootingRange;
    }

    private void CreaProjectil()
    {
        if (player != null)
        {
            GameObject fireball = Instantiate(_Fireball, transform.position, Quaternion.identity);
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();
            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
            rb.AddForce(direction * 500f);
        }
    }
}

