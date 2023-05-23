using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{

    private bool controladorPinchos = false;

    public GameObject pinchos;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CambiarControladorPinchos", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void CambiarControladorPinchos ()
    {
        controladorPinchos = !controladorPinchos;

        if (controladorPinchos)
        {
            pinchos.SetActive(true);

        } else {
            pinchos.SetActive(false);

        }
    }
}
