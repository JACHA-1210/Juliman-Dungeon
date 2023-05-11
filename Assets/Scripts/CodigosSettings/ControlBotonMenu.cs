using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlBotonMenu : MonoBehaviour
{
    public Button botonMenuPrincipal; //referencia al botón que se ocultará y mostrará
    private Scene escenaActual; //variable para almacenar la escena actual

    // Start is called before the first frame update
    void Start()
    {
        //obtener la escena actual al inicio
        escenaActual = SceneManager.GetActiveScene();

        //determinar si el botón debe estar activado o desactivado al inicio
        if (escenaActual.name == "SettingsGame")
        {
            botonMenuPrincipal.gameObject.SetActive(false); //ocultar el botón si está en SettingsGame
        }
        else
        {
            botonMenuPrincipal.gameObject.SetActive(true); //mostrar el botón en todas las demás escenas
        }
    }

    //suscribirse al evento OnSceneLoaded
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //desuscribirse del evento OnSceneLoaded
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //método que se ejecutará cuando se cambie de escena
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //actualizar la variable de la escena actual
        escenaActual = SceneManager.GetActiveScene();

        //determinar si el botón debe estar activado o desactivado en la nueva escena
        if (escenaActual.name == "SettingsGame")
        {
            botonMenuPrincipal.gameObject.SetActive(false); //ocultar el botón si está en SettingsGame
        }
        else
        {
            botonMenuPrincipal.gameObject.SetActive(true); //mostrar el botón en todas las demás escenas
        }
    }
}