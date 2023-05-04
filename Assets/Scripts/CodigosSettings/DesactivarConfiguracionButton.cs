using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesactivarConfiguracionButton : MonoBehaviour
{
    public PasarConfiguracionEntreEscenas opciones;

    void Start()
    {
        opciones = FindObjectOfType<PasarConfiguracionEntreEscenas>();
        if (opciones == null)
        {
            Debug.LogWarning("No se encontr� el objeto de configuraci�n en la escena.");
            return;
        }

        GetComponent<Button>().onClick.AddListener(DesactivarObjetoConfiguracion);
    }

    void DesactivarObjetoConfiguracion()
    {
        opciones.DesactivarObjetoConfiguracion();
    }
}