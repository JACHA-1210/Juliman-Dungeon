using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas1SinCandado : MonoBehaviour
{

    public GameObject _puertasClosed;
    public GameObject _puertasOpen;
    private bool estadoPuerta;
    private bool tocandoPuerta;
    public GameObject teclae;

    // Start is called before the first frame update
    void Start()
    {
        estadoPuerta = GameObject.Find("ControladorEstadoPuertas1").GetComponent<ControladorEstadoPuertas1>().estadoPuertaControlador;
        tocandoPuerta = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (tocandoPuerta) {

            teclae.SetActive(true);
        } else
        {
            teclae.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (tocandoPuerta)
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

        GameObject.Find("ControladorEstadoPuertas1").GetComponent<ControladorEstadoPuertas1>().CambiarEstadoPuertaControlador();
    }
}
