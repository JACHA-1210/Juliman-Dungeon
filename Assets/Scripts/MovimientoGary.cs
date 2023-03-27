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
        
        float direccioX = Input.GetAxisRaw("Horizontal");
        float direccioY = Input.GetAxisRaw("Vertical");

        Vector2 direccioIndiacada = new Vector2(direccioX, direccioY).normalized;

        Vector2 posNau = transform.position;

        posNau = posNau + direccioIndiacada * _velGary * Time.deltaTime;

        transform.position = posNau;

        anim.SetFloat("Camina", Mathf.Abs(direccioX));
    }
}
