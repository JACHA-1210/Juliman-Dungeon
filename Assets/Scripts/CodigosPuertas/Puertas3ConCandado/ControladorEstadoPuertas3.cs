using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEstadoPuertas3 : MonoBehaviour
{

    public bool estadoPuertaControlador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarEstadoPuertaControlador()
    {
        estadoPuertaControlador = !estadoPuertaControlador;
    }
}
