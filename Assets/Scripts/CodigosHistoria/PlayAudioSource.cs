using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioSource : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource teclas;
    void Start()
    {
        teclas.pitch = 0.5f;
        teclas.volume = 1.0f;
        teclas.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
