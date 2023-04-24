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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            MostrarOpciones();

        }
        
    }

    public void MostrarOpciones()
    {
        PanelOpciones.pantallaOpciones.SetActive(true);
    }
}
