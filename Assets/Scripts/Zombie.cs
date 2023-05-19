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

    private bool ZombieVivo = true;

    public GameObject zombieGlobal;

    public GameObject colZombie;

    public GameObject _zombieMuertePrefab;

    private bool controladorEspada = true;

    private bool usandoEspada = false;

    private void Start()
    {
        Gary = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        spriteZombie = GameObject.Find("AnimadorZombie").GetComponent<SpriteRenderer>();
        GaryVivo = GameObject.Find("Gary").GetComponent<MovimientoGary>().GaryVivo;

        if (JugadorCerca && Gary != null && GaryVivo)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direction = Gary.position - transform.position;
            direction.Normalize();

            // Mueve el zombie hacia el jugador
            zombieGlobal.transform.position += direction * _vel * Time.deltaTime;

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
        }
        else
        {
            anim.SetTrigger("Quieto");
        }

        //Espadas
        if (Input.GetMouseButton(0) && !GameObject.Find("Gary").GetComponent<MovimientoGary>().siendoEmpujado)
        {
            usandoEspada = true;
            Invoke("NoUsandoEspada", 0.8f);
        }

        if (GameObject.Find("EspadasHitboxPersonaje").GetComponent<EspadasHitboxPersonaje>().colisionandoConZombie && usandoEspada && controladorEspada)
        {
            Invoke("EspadaTocaZombie", 0.1f);
        }
    }

    public void EspadaTocaZombie()
    {       
        MuerteZombie();
        controladorEspada = false;
        Invoke("CambiarControladorEspada", 0.8f);
        
    }

    public void CambiarControladorEspada()
    {
        controladorEspada = true;
    }

    public void NoUsandoEspada()
    {
        usandoEspada = false;
    }

    public void MuerteZombie()
    {
        if (ZombieVivo)
        {
            Vector2 posZombie = GameObject.Find("EspadasHitboxPersonaje").GetComponent<EspadasHitboxPersonaje>().collisionGlobal.transform.position;
            Instantiate(_zombieMuertePrefab, posZombie, Quaternion.identity);
            Destroy(GameObject.Find("EspadasHitboxPersonaje").GetComponent<EspadasHitboxPersonaje>().collisionGlobal); // Destruir este objeto Zombie
            ZombieVivo = false;
            GameObject.Find("Gary").GetComponent<MovimientoGary>().colisionandoConZombie = false;
            Invoke("ControladorZombieVivo", 0.7f);
        }
        
    }

    public void ControladorZombieVivo()
    {
        ZombieVivo = true;
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
