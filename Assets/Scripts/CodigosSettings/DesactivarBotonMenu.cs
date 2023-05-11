using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DesactivarBotonMenuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Scene escenaActual = SceneManager.GetActiveScene();

        // Comprobar si es la escena "SettingsGame"
        if (escenaActual.name == "SettingsGame")
        {
            // Ocultar el bot�n si est� en la escena "SettingsGame"
            gameObject.SetActive(false);
        }
        else if (escenaActual.name == "JugarNivel1")
        {
            // Mostrar el bot�n si est� en la escena "JugarNivel1"
            gameObject.SetActive(true);
        }
    }
}