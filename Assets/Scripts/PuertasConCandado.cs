using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertasConCandado : MonoBehaviour
{

    public GameObject _puertasClosed;
    public GameObject _puertasOpen;
    private bool estadoPuerta;
    private bool tocandoPuerta;
    public bool llaveObtenida;

    // Start is called before the first frame update
    void Start()
    {
        estadoPuerta = GameObject.Find("ControladorEstadoPuerta").GetComponent<ControladorEstadoPuerta>().estadoPuertaControlador;
        tocandoPuerta = false;
        llaveObtenida = false;
    }

    // Update is called once per frame
    void Update()
    {
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

        GameObject.Find("ControladorEstadoPuerta").GetComponent<ControladorEstadoPuerta>().CambiarEstadoPuertaControlador();
    }
}
