using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DesactivarBoton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Scene escenaActual = SceneManager.GetActiveScene();
       

        if (escenaActual.name == "SettingsGame")
        {
            gameObject.SetActive(false);
        }
        else if (escenaActual.name == "JugarNivel1")
        {
            gameObject.SetActive(true);
        }
    }
}