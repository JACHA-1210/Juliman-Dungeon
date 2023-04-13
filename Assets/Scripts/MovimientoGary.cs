using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoGary : MonoBehaviour
{

    public float _velGary;

    private SpriteRenderer spritePersonaje;

    public GameObject Gary;

    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        _velGary = 4f;
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

        Vector2 direccioIndiacada = new Vector2(direccioX, direccioY).normalized;

        Vector2 posGary = transform.position;

        posGary = posGary + direccioIndiacada * _velGary * Time.deltaTime;

        transform.position = posGary;

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

    }
}
