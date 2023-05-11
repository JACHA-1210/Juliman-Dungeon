using UnityEngine;
using UnityEngine.SceneManagement;

public class DesactivarBoton : MonoBehaviour
{
    public GameObject botonMenuPrincipal;

    private void OnEnable()
    {
        Scene escenaActual = SceneManager.GetActiveScene();

        if (escenaActual.name == "SettingsGame")
        {
            botonMenuPrincipal.SetActive(false);
        }
        else if (escenaActual.name == "JugarNivel1")
        {
            botonMenuPrincipal.SetActive(true);
        }
    }
}
