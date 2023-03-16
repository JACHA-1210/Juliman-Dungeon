using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoGary : MonoBehaviour
{
    public Rigidbody2D rbd;

    public float _velGary = 20f;

    public GameObject Gary; 


    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float direccioX = Input.GetAxisRaw("Horizontal");
        float direccioY = Input.GetAxisRaw("Vertical");

        rbd.velocity = new Vector2(direccioX * _velGary, rbd.velocity.x);
        rbd.velocity = new Vector2(direccioY * _velGary, rbd.velocity.y);

        Vector2 novaPos = new Vector2(transform.position.x + _velGary * direccioX, transform.position.y + _velGary * direccioY);    

        transform.position = novaPos;
        
    }
}
