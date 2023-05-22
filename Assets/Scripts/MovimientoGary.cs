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

    public bool siendoEmpujado;
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

    public bool colisionandoConZombie = false;
    public bool colisionandoConBoss = false;
    public bool colisionandoConFireball = false;

    public GameObject espadaHitboxIzquierda;
    public GameObject espadaHitboxDerecha;

    public GameObject colisionFireball;

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

        // Obtén todos los colliders del Zombie
        BossColManager[] BossColliders = FindObjectsOfType<BossColManager>();

        // Ignora la colisión entre el collider del personaje y los colliders del Zombie
        foreach (BossColManager BossCollider in BossColliders)
        {
            Collider2D BossChildCollider = BossCollider.GetComponentInChildren<BoxCollider2D>();
            Collider2D BossParentCollider = BossCollider.GetComponent<BoxCollider2D>();

            // Ignora la colisión entre el collider del personaje y el collider del objeto secundario del Zombie
            Physics2D.IgnoreCollision(playerCollider, BossChildCollider);

            // Ignora la colisión entre el collider del personaje y el collider del Zombie
            Physics2D.IgnoreCollision(playerCollider, BossParentCollider);
        }

        vida = 5;
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        spritePersonaje = GameObject.Find("Animador").GetComponent<SpriteRenderer>();
        colorNormal = spritePersonaje.color;
        colorInvencible = new Color(1f, 1f, 1f, 0.5f); // Ajusta los valores según desees

        espadaHitboxIzquierda.SetActive(false);
        espadaHitboxDerecha.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if (Gary != null)
        {
            espadaHitboxIzquierda.transform.position = Gary.transform.position;
            espadaHitboxDerecha.transform.position = Gary.transform.position;
        }       

        if (GaryVivo)
        {
            //Moverse

            float direccioX = Input.GetAxisRaw("Horizontal");
            float direccioY = Input.GetAxisRaw("Vertical");

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                _velGary = 5f; // Si se mantiene presionada la tecla Shift, establecer _velGary en 20
            }
            else
            {
                _velGary = 3f; // Si no se mantiene presionada la tecla Shift, establecer _velGary en 3
            }

            float totalDireccio = Mathf.Abs(direccioX) + Mathf.Abs(direccioY);

            anim.SetFloat("Moverse", Mathf.Abs(totalDireccio));

            rbd.velocity = new Vector2(direccioX * _velGary, direccioY * _velGary);

            if (direccioX < 0)
            {

                spritePersonaje.flipX = true;
                espadaHitboxIzquierda.SetActive(true);
                espadaHitboxDerecha.SetActive(false);

            }

            else if (direccioX > 0)
            {

                spritePersonaje.flipX = false;
                espadaHitboxIzquierda.SetActive(false);
                espadaHitboxDerecha.SetActive(true);

            }

            //Ataque espada 
            if (Input.GetMouseButton(0) && !siendoEmpujado)
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

            // Gary cuando recibe daño de los zombies

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

        //Vida controlador

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

        // Comprobar colisión con ColZombie después de que la invencibilidad termine
        if (!esInvencible && (colisionandoConZombie || colisionandoConBoss || colisionandoConFireball))
        {
            if (GaryVivo)
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

        Debug.Log(colisionandoConBoss + " " + colisionandoConFireball);

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
            colisionandoConZombie = true;
        }

        if (collision.tag == "Colboss")
        {
            colisionandoConBoss = true;
        }

        if (collision.tag == "Fireball")
        {
            colisionFireball = collision.gameObject;
            colisionandoConFireball = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ColZombie")
        {
            colisionandoConZombie = false;
        }

        if (collision.tag == "Colboss")
        {
            colisionandoConBoss = false;
        }


        if (collision.tag == "Fireball")
        {
            colisionandoConFireball = false;
            
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
