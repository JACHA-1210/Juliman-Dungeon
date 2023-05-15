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

    public GameObject[] barrasDeVida;
    private int vida;

    private Animator anim;

    //Objetos llaves
    public GameObject llavePuertas2;
    public GameObject llavePuertas3;

    // Start is called before the first frame update
    void Start()
    {
        vida = 5;
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        spritePersonaje = GameObject.Find("Animador").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
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

        //Vida

        if (vida < 1)
        {
            Destroy(barrasDeVida[0].gameObject);
            SceneManager.LoadScene("GameOver");
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
            vida--;
        }
    }
}
