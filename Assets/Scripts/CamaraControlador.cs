using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControlador : MonoBehaviour
{
    public GameObject guille;
    private Vector3 diferencia;
    // Start is called before the first frame update
    void Start()
    {
        diferencia = transform.position - guille.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (guille.transform.position.x >= 0)
        {
            Vector3 nuevaPos = guille.transform.position + diferencia;
            transform.position = nuevaPos;
        }
        
    }
}
