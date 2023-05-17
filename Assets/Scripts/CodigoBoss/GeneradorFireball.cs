using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorFireball : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject _Fireball;
    void Start()
    {
        InvokeRepeating("CreaProjectil", 0.2f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreaProjectil()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            GameObject Fireball = Instantiate(_Fireball);
            Fireball.transform.position = transform.position;
        }
    }
}
