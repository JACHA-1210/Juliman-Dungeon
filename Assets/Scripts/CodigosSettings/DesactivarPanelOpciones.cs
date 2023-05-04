using UnityEngine;

public class DesactivarPanelOpciones : MonoBehaviour
{
    void Start()
    {
        // Buscar el objeto que contiene el panel de opciones
        GameObject objetoPanelOpciones = GameObject.Find("PanelOpciones");

        // Si se encontró el objeto, desactivar el panel de opciones
        if (objetoPanelOpciones != null)
        {
            objetoPanelOpciones.SetActive(false);
            Time.timeScale = 1; // Pausar el juego
        }
    }
}