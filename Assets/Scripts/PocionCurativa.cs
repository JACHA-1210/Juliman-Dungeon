using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PocionCurativa : MonoBehaviour
{

    public GameObject[] barrasDeVida;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (GameObject.Find("Gary").GetComponent<MovimientoGary>().vida != 5)
            {
                GameObject.Find("Gary").GetComponent<MovimientoGary>().vida++;

                if (GameObject.Find("Gary").GetComponent<MovimientoGary>().vida == 2)
                {
                    barrasDeVida[1].SetActive(true);
                }
                else if (GameObject.Find("Gary").GetComponent<MovimientoGary>().vida == 3)
                {
                    barrasDeVida[2].SetActive(true);
                }
                else if (GameObject.Find("Gary").GetComponent<MovimientoGary>().vida == 4)
                {
                    barrasDeVida[3].SetActive(true);
                }
                else if (GameObject.Find("Gary").GetComponent<MovimientoGary>().vida == 5)
                {
                    barrasDeVida[4].SetActive(true);
                }

                Destroy(gameObject);

            }
        }
    }
}
