using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca3 : MonoBehaviour
{

    public GameObject palancaOff;
    public GameObject palancaOn;

    public GameObject barrera3;

    public GameObject teclaePalanca3;

    private bool tocandoPalanca;
    private bool estadoPalanca = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tocandoPalanca)
        {

            teclaePalanca3.SetActive(true);
        }
        else
        {
            teclaePalanca3.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (tocandoPalanca)
            {
                InteractuarConPalanca();
            }
        }
    }

    private void InteractuarConPalanca()
    {
        estadoPalanca = !estadoPalanca;

        if (!estadoPalanca)
        {
            palancaOff.SetActive(false);
            palancaOn.SetActive(true);

            barrera3.SetActive(false);

        } else
        {
            palancaOff.SetActive(true);
            palancaOn.SetActive(false);

            barrera3.SetActive(true);

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            tocandoPalanca = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            tocandoPalanca = false;
        }
    }
}
