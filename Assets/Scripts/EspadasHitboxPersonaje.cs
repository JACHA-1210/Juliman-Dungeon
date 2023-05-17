using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadasHitboxPersonaje : MonoBehaviour
{

    public GameObject espadaHitboxIzquierda;
    public GameObject espadaHitboxDerecha;

    private bool colisionandoConZombie = false;

    private bool controladorEspada = true;

    private bool usandoEspada = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Enemic") != null)
        {
            if (Input.GetMouseButton(0) && !GameObject.Find("Gary").GetComponent<MovimientoGary>().siendoEmpujado)
            {
                usandoEspada = true;
                Invoke("UsandoEspada", 0.8f);
            }

            if (colisionandoConZombie && usandoEspada && controladorEspada)
            {
                Invoke("EspadaTocaZombie", 0.1f);
            }
        }
        
    }

    public void EspadaTocaZombie ()
    {
        GameObject.FindGameObjectWithTag("Enemic").GetComponent<Zombie>().DestroyZombie();
        controladorEspada = false;
        Invoke("CambiarControladorEspada", 0.8f);
    }

    public void CambiarControladorEspada ()
    {
        controladorEspada = true;
    }

    public void UsandoEspada()
    {
        usandoEspada = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ColZombie")
        {
            colisionandoConZombie = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ColZombie")
        {
            colisionandoConZombie = false;
        }
    }
}
