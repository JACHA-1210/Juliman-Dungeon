using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSonidoMuerto : MonoBehaviour
{

    public AudioSource BossAudioSource; // Referencia al componente AudioSource
    public AudioClip destruccionSound; // Sonido de destrucción

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EjecutarSonidoMuerteBoss()
    {
        if (GameObject.Find("Boss").GetComponent<Boss>().bossMuerto)
        {
            // Reproducir el sonido de destrucción
            if (BossAudioSource != null && destruccionSound != null)
            {
                BossAudioSource.PlayOneShot(destruccionSound);
            }
        }
    }

}
