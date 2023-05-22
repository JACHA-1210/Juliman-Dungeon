using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update

    private float _vel = 1f; // Velocidad de movimiento del boss
    private Transform Gary; // Referencia al jugador
    private bool JugadorCerca = false; // Indicador de seguimiento activo
    private SpriteRenderer spriteBoss;

    private Animator anim;

    public GameObject bossGlobal;

    private bool GaryVivo = true;

    private bool BossVivo = true;

    private bool controladorEspada = true;

    private bool usandoEspada = false;

    private bool golpeAplicado = false;

    private int vida;

    private void Start()
    {
        vida = 10;
        Gary = GameObject.FindGameObjectWithTag("Player").transform;
        spriteBoss = GameObject.Find("BossAnimacion").GetComponent<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {

        GaryVivo = GameObject.Find("Gary").GetComponent<MovimientoGary>().GaryVivo;

        

        if (JugadorCerca && Gary != null && GaryVivo)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direction = Gary.position - transform.position;
            direction.Normalize();

            // Mueve el boss hacia el jugador
            bossGlobal.transform.position += direction * _vel * Time.deltaTime;

            anim.SetTrigger("Moverse");

            // Girar el objeto hacia la izquierda o derecha
            if (direction.x < 0)
            {
                spriteBoss.flipX = true; // Invertir la escala horizontalmente
            }
            else if (direction.x > 0)
            {
                spriteBoss.flipX = false; // Mantener la escala original
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

        if (GameObject.Find("EspadasHitboxPersonaje").GetComponent<EspadasHitboxPersonaje>().colisionandoConBoss && usandoEspada && controladorEspada)
        {
            Invoke("EspadaTocaBoss", 0.1f);
        }
    }

    public void EspadaTocaBoss()
    {
        if (!golpeAplicado)
        {
            GolpeBoss();
            controladorEspada = false;
            golpeAplicado = true; // Marcar el golpe como aplicado
            Invoke("CambiarControladorEspada", 0.8f);
        }
    }

    public void CambiarControladorEspada()
    {
        controladorEspada = true;
        golpeAplicado = false;
    }

    public void NoUsandoEspada()
    {
        usandoEspada = false;
    }

    public void GolpeBoss()
    {
        vida--;

        if (BossVivo)
        {
            if (vida < 1)
            {
                Debug.Log(vida);
                bossGlobal.SetActive(false);
                Invoke("PasarEscenaPantallaFinal", 2f);
            }

        }

    }

    public void ControladorBossVivo()
    {
        BossVivo = true;
    }

    public void PasarEscenaPantallaFinal()
    {
        SceneManager.LoadScene("PantallaFinal");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // El jugador ha entrado en el rango del boss
            // Inicia el seguimiento del jugador
            JugadorCerca = true;
        }
    }
}
