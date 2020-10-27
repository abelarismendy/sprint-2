using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avispa1 : MonoBehaviour
{
    public float velocidad;
    public Vector3 posInicial;
    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3((transform.position.x - Time.deltaTime * velocidad), Mathf.Sin(Time.time) + posInicial.y, transform.position.z);
        if(transform.position.x < -10.0f) {
            transform.position = posInicial;
        }
    }
}
