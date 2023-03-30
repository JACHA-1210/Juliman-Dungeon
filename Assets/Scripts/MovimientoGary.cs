using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoGary : MonoBehaviour
{

    public float _velGary;

    public GameObject Gary;

    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        _velGary = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            anim.SetTrigger("Moviendose");
        }

        float direccioX = Input.GetAxisRaw("Horizontal");
        float direccioY = Input.GetAxisRaw("Vertical");

        Vector2 direccioIndiacada = new Vector2(direccioX, direccioY).normalized;

        Vector2 posGary = transform.position;

        posGary = posGary + direccioIndiacada * _velGary * Time.deltaTime;

        transform.position = posGary;

        //Ataque espada 
        if (Input.GetMouseButton(0))
        {
            anim.SetTrigger("Atacar");
        }


    }
}
