using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avispa1 : MonoBehaviour
{
    public float velocidad;
    // Start is called before the first frame update
    Vector3 pos;
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos += transform.forward * Time.deltaTime * velocidad;
        transform.position = pos + transform.up * Mathf.Sin(Time.time);
    }
}
