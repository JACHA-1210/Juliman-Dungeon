using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsActive : MonoBehaviour
{

    public ControladorDeOpciones PanelOpciones;


    private void Start()
    {

        PanelOpciones = GameObject.FindGameObjectWithTag("Opciones").GetComponent<ControladorDeOpciones>();
        PanelOpciones.pantallaOpciones.SetActive(true);
    }
}
