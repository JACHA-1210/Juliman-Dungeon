using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas2ConCandado : MonoBehaviour
{

    public GameObject _puertasClosed;
    public GameObject _puertasOpen;
    private bool estadoPuerta;
    private bool tocandoPuerta;
    private bool llaveObtenida;
    public GameObject teclae2;

    // Start is called before the first frame update
    void Start()
    {
        estadoPuerta = GameObject.Find("ControladorEstadoPuertas2").GetComponent<ControladorEstadoPuertas2>().estadoPuertaControlador;
        tocandoPuerta = false;
        llaveObtenida = GameObject.Find("ControladorLlavePuertas2").GetComponent<ControladorLlavePuertas2>().estadoLlave;
    }

    // Update is called once per frame
    void Update()
    {

        if (tocandoPuerta && llaveObtenida)
        {
            teclae2.SetActive(true);

        } else
        {
            teclae2.SetActive(false);

        }

        llaveObtenida = GameObject.Find("ControladorLlavePuertas2").GetComponent<ControladorLlavePuertas2>().estadoLlave;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (tocandoPuerta && llaveObtenida)
            {
                InteractuarConPuerta();
            }          
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            tocandoPuerta = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            tocandoPuerta = false;
        }
    }

    public void InteractuarConPuerta()
    {
        if (!estadoPuerta)
        {
            _puertasClosed.SetActive(false);
            _puertasOpen.SetActive(true);

        }
        else
        {
            _puertasClosed.SetActive(true);
            _puertasOpen.SetActive(false);

        }

        GameObject.Find("ControladorEstadoPuertas2").GetComponent<ControladorEstadoPuertas2>().CambiarEstadoPuertaControlador();
    }
}
