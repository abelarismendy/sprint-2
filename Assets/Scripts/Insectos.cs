using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insectos : MonoBehaviour
{
    public float velocidad;
    public float rango;
    public float rotacionY;
    private bool adelante;
    private float IniPos;
    private float diferencia;
    void Start()
    {
        IniPos = transform.position.x;
        adelante = true;
    }

    // Update is called once per frame
    void Update()
    {
        diferencia = transform.position.x - IniPos;
        if (adelante){
            transform.position = new Vector3((transform.position.x + velocidad * Time.deltaTime), transform.position.y, transform.position.z );
            // transform.position.z += velocidad * Time.time;
        }

        else {
            transform.position = new Vector3((transform.position.x - velocidad * Time.deltaTime), transform.position.y, transform.position.z );
        }

        if (diferencia >= rango){
            transform.rotation = Quaternion.Euler(rotacionY, 270.0f, transform.rotation.z);
            // transform.rotation = Quaternion.Euler(0.0f,Mathf.PingPong(Time.time * 50, rotacion*2)-280, 0.0f);
            adelante = false;
        }

        if (diferencia <= -rango){
            transform.rotation = Quaternion.Euler(rotacionY, 90.0f, transform.rotation.z);
            // transform.rotation = Quaternion.Euler(0.0f,Mathf.PingPong(Time.time * 50, rotacion*2)-100, 0.0f);
            adelante = true;
        }
    }
}
