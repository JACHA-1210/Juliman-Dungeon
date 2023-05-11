using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsActive : MonoBehaviour
{

    public ControladorDeOpciones PanelOpciones;

    private void Start()
    {

        PanelOpciones = GameObject.FindGameObjectWithTag("Opciones").GetComponent<ControladorDeOpciones>();
        PanelOpciones.pantallaOpciones.SetActive(true);
    }
}
