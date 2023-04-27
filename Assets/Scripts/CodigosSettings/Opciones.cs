using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opciones : MonoBehaviour
{
    public ControladorDeOpciones PanelOpciones;

    // Start is called before the first frame update
    void Start()
    {
        PanelOpciones = GameObject.FindGameObjectWithTag("Opciones").GetComponent<ControladorDeOpciones>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PanelOpciones.pantallaOpciones.activeSelf)
            {
                OcultarOpciones();
            }
            else
            {
                MostrarOpciones();
            }
        }

    }

    public void MostrarOpciones()
    {
        Time.timeScale = 0; // Pausar el juego
        PanelOpciones.pantallaOpciones.SetActive(true);
    }

    public void OcultarOpciones()
    {
        Time.timeScale = 1; // Pausar el juego
        PanelOpciones.pantallaOpciones.SetActive(false);
    }
}
