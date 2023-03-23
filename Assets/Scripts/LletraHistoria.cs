using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LletraHistoria : MonoBehaviour
{

    string historia = " En este mundo distópico lleno de tesoros y aventuras," +
        "Gary, nuestro protagonista, gran amante de las aventuras con riesgos asegurados, ha estado investigando un libro, que le heredó de su abuelo (un gran aventurero de su época) que data de la fecha de 1897, en el cual sale información acerca de un tesoro, jamás visto ni encontrado, el cual contiene segun dice el espiritu mas deseado por cualquier ser vivo que hay en la faz de la Tierra.\n" +
        "Gary está decidido a encontrar este tesoro y ser el primero en poner sus manos en él. Sin embargo, también sabe que la búsqueda no será fácil. Hay peligros en cada esquina y competidores despiadados que harán cualquier cosa para obtener el tesoro antes que él. Pero Gary no se deja intimidar y está dispuesto a tomar los riesgos necesarios para alcanzar su objetivo.\n" +
        "\r\nEmprende su viaje a través de un mundo peligroso y desconocido, enfrentándose a desafíos y superando obstáculos. A medida que avanza en su búsqueda, Gary descubre que el tesoro es más valioso y peligroso de lo que jamás hubiera imaginado.\n" + "\r\nCon cada paso, Gary se acerca más al tesoro, pero también se encuentra con más competidores y peligros. \r\nGary se adentra en la mazmorra en busca del tesoro legendario. En cada sala de la mazmorra, se encuentra con diferentes enemigos y “jefes” que intentan detenerlo en su camino.\r\n";

    public Text texto;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reloj());
    }

    IEnumerator Reloj()
    {
       foreach(char caracter in historia)
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
