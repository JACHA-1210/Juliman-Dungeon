using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LletraHistoria : MonoBehaviour
{

    string historia = " En este mundo dist�pico lleno de tesoros y aventuras," +
        "Gary, nuestro protagonista, gran amante de las aventuras con riesgos asegurados, ha estado investigando un libro, que le hered� de su abuelo (un gran aventurero de su �poca) que data de la fecha de 1897, en el cual sale informaci�n acerca de un tesoro, jam�s visto ni encontrado, el cual contiene segun dice el espiritu mas deseado por cualquier ser vivo que hay en la faz de la Tierra.\n";
   
    string historia2 ="Gary est� decidido a encontrar este tesoro y ser el primero en poner sus manos en �l. Sin embargo, tambi�n sabe que la b�squeda no ser� f�cil. Hay peligros en cada esquina y competidores despiadados que har�n cualquier cosa para obtener el tesoro antes que �l. Pero Gary no se deja intimidar y est� dispuesto a tomar los riesgos necesarios para alcanzar su objetivo.\n" +
        "\r\nEmprende su viaje a trav�s de un mundo peligroso y desconocido, enfrent�ndose a desaf�os y superando obst�culos. A medida que avanza en su b�squeda, Gary descubre que el tesoro es m�s valioso y peligroso de lo que jam�s hubiera imaginado.\n" + "\r\nCon cada paso, Gary se acerca m�s al tesoro, pero tambi�n se encuentra con m�s competidores y peligros. \r\nGary se adentra en la mazmorra en busca del tesoro legendario. En cada sala de la mazmorra, se encuentra con diferentes enemigos y �jefes� que intentan detenerlo en su camino.\r\n";
    

    public Text texto1;
    public Text texto2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reloj());
    }

    IEnumerator Reloj()
    {
       foreach(char caracter in historia)
        {
            texto1.text = texto1.text + caracter;
            yield return new WaitForSeconds(0.01f);
        }

        foreach (char caracter in historia2)
        {
            texto2.text = texto2.text + caracter;
            yield return new WaitForSeconds(0.01f);
        }

    }
}
