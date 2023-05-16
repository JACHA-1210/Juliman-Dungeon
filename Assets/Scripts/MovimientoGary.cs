using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoGary : MonoBehaviour
{
    private Rigidbody2D rbd;

    public float _velGary;

    private SpriteRenderer spritePersonaje;

    public GameObject Gary;

    public bool GaryVivo = true;

    public GameObject[] barrasDeVida;
    private int vida;

    private bool siendoEmpujado;
    private Vector2 direccionEmpuje;
    private float duracionEmpuje;
    private float tiempoInicioEmpuje;

    private bool esInvencible = false;
    public float duracionInvencibilidad = 2.0f; // Duración de 3 segundos, ajusta según necesites

    public Color colorNormal;
    public Color colorInvencible;

    private Animator anim;

    //Objetos llaves
    public GameObject llavePuertas2;
    public GameObject llavePuertas3;

    // Start is called before the first frame update
    void Start()
    {

        // Obtén una referencia al collider del personaje
        BoxCollider2D playerCollider = GetComponent<BoxCollider2D>();

        // Obtén todos los colliders del Zombie
        ZombieColliderManager[] zombieColliders = FindObjectsOfType<ZombieColliderManager>();

        // Ignora la colisión entre el collider del personaje y los colliders del Zombie
        foreach (ZombieColliderManager zombieCollider in zombieColliders)
        {
            Collider2D zombieChildCollider = zombieCollider.GetComponentInChildren<BoxCollider2D>();
            Collider2D zombieParentCollider = zombieCollider.GetComponent<BoxCollider2D>();

            // Ignora la colisión entre el collider del personaje y el collider del objeto secundario del Zombie
            Physics2D.IgnoreCollision(playerCollider, zombieChildCollider);

            // Ignora la colisión entre el collider del personaje y el collider del Zombie
            Physics2D.IgnoreCollision(playerCollider, zombieParentCollider);
        }

        vida = 5;
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        spritePersonaje = GameObject.Find("Animador").GetComponent<SpriteRenderer>();
        colorNormal = spritePersonaje.color;
        colorInvencible = new Color(1f, 1f, 1f, 0.5f); // Ajusta los valores según desees
    }

    // Update is called once per frame
    void Update()
    {

        if (GaryVivo)
        {
            //Moverse

            float direccioX = Input.GetAxisRaw("Horizontal");
            float direccioY = Input.GetAxisRaw("Vertical");

            float totalDireccio = Mathf.Abs(direccioX) + Mathf.Abs(direccioY);

            anim.SetFloat("Moverse", Mathf.Abs(totalDireccio));

            rbd.velocity = new Vector2(direccioX * _velGary, direccioY * _velGary);

            if (direccioX < 0)
            {

                spritePersonaje.flipX = true;

            }

            else if (direccioX > 0)
            {

                spritePersonaje.flipX = false;

            }

            //Ataque espada 
            if (Input.GetMouseButton(0))
            {
                anim.SetFloat("Moverse", Mathf.Abs(0));
                anim.SetFloat("Atacar", Mathf.Abs(1));
            }

            // Verificar si la animación de "Atacar" ha terminado
            AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("Atacar") && stateInfo.normalizedTime >= 1.0f)
            {
                // Restablecer el valor del float "Atacar" a 0
                anim.SetFloat("Atacar", 0);
            }

            if (siendoEmpujado)
            {
                float tiempoTranscurrido = Time.time - tiempoInicioEmpuje;
                if (tiempoTranscurrido < duracionEmpuje)
                {
                    rbd.velocity = direccionEmpuje * _velGary;
                }
                else
                {
                    siendoEmpujado = false;
                    rbd.velocity = Vector2.zero;
                }
            }
        }

        //Invencibilidad

        if (GaryVivo)
        {
            if (esInvencible)
            {
                if (GaryVivo)
                {
                    spritePersonaje.color = colorInvencible;
                }
                
            }
            else
            {
                if (GaryVivo)
                {
                    spritePersonaje.color = colorNormal;
                }
            }
        }

        //Vida

        if (vida < 1)
        {
            Destroy(barrasDeVida[0].gameObject);
            anim.SetTrigger("SinVidas");
            GaryVivo = false;
            _velGary = 0;

            rbd.velocity = Vector2.zero;
            Invoke("PasarEscenaGameOver", 2f);
        }
        else if (vida < 2)
        {
            Destroy(barrasDeVida[1].gameObject);
        }
        else if (vida < 3)
        {
            Destroy(barrasDeVida[2].gameObject);
        }
        else if (vida < 4)
        {
            Destroy(barrasDeVida[3].gameObject);
        }
        else if (vida < 5)
        {
            Destroy(barrasDeVida[4].gameObject);
        }

    }

    public void PasarEscenaGameOver ()
    {
        SceneManager.LoadScene("GameOver");

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TpZonaBoss")
        {
            
            Gary.transform.position = GameObject.FindWithTag("UbicacionTpBoss").transform.position;
        }

        if (collision.tag == "LlavePuertas2")
        {
            GameObject.Find("ControladorLlavePuertas2").GetComponent<ControladorLlavePuertas2>().CambiarEstadoLlaveControlador();
            Destroy(llavePuertas2);
        }

        if (collision.tag == "LlavePuertas3")
        {
            GameObject.Find("ControladorLlavePuertas3").GetComponent<ControladorLlavePuertas3>().CambiarEstadoLlaveControlador();
            Destroy(llavePuertas3);
        }

        if (collision.tag == "ColZombie")
        {
            if (GaryVivo && !esInvencible)
            {
                Invoke("RestarVida", 0.1f);

                // Aplicar el efecto de invencibilidad
                esInvencible = true;
                Invoke("TerminarInvencibilidad", duracionInvencibilidad);

                // Aplicar el empuje
                siendoEmpujado = true;
                direccionEmpuje = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                duracionEmpuje = 0.5f;
                tiempoInicioEmpuje = Time.time;
            }
        }
    }
    private void TerminarInvencibilidad()
    {
        esInvencible = false;
    }

    public void RestarVida ()
    {
        vida--;
    }
}
