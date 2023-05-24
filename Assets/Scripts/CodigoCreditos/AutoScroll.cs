using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour
{
    public float scrollSpeed = 1f;   // Velocidad de desplazamiento del texto
    public float scrollDelay = 1f;   // Retardo antes de empezar a desplazar el texto
    private bool isScrolling = false; // Indicador de desplazamiento activo
    private RectTransform textTransform;
    private Vector2 startPosition;   // Posición inicial del texto

    private void Start()
    {
        // Obtener la referencia al componente RectTransform del objeto de texto
        textTransform = GetComponent<RectTransform>();

        // Guardar la posición inicial del texto
        startPosition = textTransform.anchoredPosition;

        // Iniciar el desplazamiento del texto después del retardo
        Invoke("StartScrolling", scrollDelay);
    }

    private void Update()
    {
        if (isScrolling)
        {
            // Mover el texto hacia arriba en el eje Y
            textTransform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);

            // Reiniciar la posición del texto cuando haya salido de la pantalla
            if (textTransform.anchoredPosition.y >= Screen.height)
            {
                textTransform.anchoredPosition = startPosition;
            }
        }
    }

    private void StartScrolling()
    {
        isScrolling = true;
    }
}
