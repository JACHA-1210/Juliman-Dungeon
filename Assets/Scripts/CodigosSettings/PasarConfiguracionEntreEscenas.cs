using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasarConfiguracionEntreEscenas : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {

        var noDestruirEntreEscenas = FindObjectsOfType<PasarConfiguracionEntreEscenas>();
        if(noDestruirEntreEscenas.Length > 1)

        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        PasarConfiguracionEntreEscenas opciones = FindObjectOfType<PasarConfiguracionEntreEscenas>();
        if (opciones != null)
        {
            opciones.gameObject.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
