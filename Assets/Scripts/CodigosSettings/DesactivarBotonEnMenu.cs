using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarBotonEnMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Buscar el objeto que contiene el panel de opciones
        GameObject objetoPanelOpciones = GameObject.Find("BotonVolverMenu");

        // Si se encontró el objeto, desactivar el panel de opciones
        if (objetoPanelOpciones != null)
        {
            objetoPanelOpciones.SetActive(true);
     
        }

    }

  
}
