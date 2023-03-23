using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    //variables2
    public GameObject Gary;
    public Vector2 minimo;
    public Vector2 maximo;
    public float suavizado;
    Vector2 velocity;
    //prova gitkraken
    void Update()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, Gary.transform.position.x, ref velocity.x, suavizado);
        float posY = Mathf.SmoothDamp(transform.position.y, Gary.transform.position.y, ref velocity.y, suavizado);

        transform.position = new Vector3(Mathf.Clamp(posX,minimo.x,maximo.x),Mathf.Clamp(posY,minimo.y,maximo.y), transform.position.z);
    }
}