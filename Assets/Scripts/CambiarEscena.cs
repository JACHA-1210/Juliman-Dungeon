using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    private string nombreEscena1;
    private Animator animator;

    void Start()
    {     
        animator = GetComponent<Animator>();           
    }

    public void cargarEscena(string nombreEscena)
    {
        nombreEscena1 = nombreEscena;
        animator.SetTrigger("StartTransition");
        
        Invoke("test", 1f);
    }

    public void test()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nombreEscena1);
    }
}
