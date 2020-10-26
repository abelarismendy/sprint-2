using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insectos : MonoBehaviour
{
    public float velocidad;
    public float rango;
    public float rotacionX;
    public bool volador;
    private bool adelante;
    private Vector3 IniPos;
    private float diferencia;
    void Start()
    {
        IniPos = transform.position;
        adelante = true;
    }

    // Update is called once per frame
    void Update()
    {
        diferencia = transform.position.x - IniPos.x;
        if (adelante){
            transform.position = new Vector3((transform.position.x + velocidad * Time.deltaTime), transform.position.y, transform.position.z );
            // transform.position.z += velocidad * Time.time;
            transform.rotation = Quaternion.Euler(rotacionX,Mathf.PingPong(Time.time * velocidad * 10, 20)+80, 0.0f);
        }

        else {
            transform.position = new Vector3((transform.position.x - velocidad * Time.deltaTime), transform.position.y, transform.position.z );
            transform.rotation = Quaternion.Euler(rotacionX,Mathf.PingPong(Time.time * velocidad * 10, 20)+260, 0.0f);
        }

        if (diferencia >= rango){
            transform.rotation = Quaternion.Euler(rotacionX, 270.0f, transform.rotation.z);
            adelante = false;
            // transform.rotation = Quaternion.Euler(0.0f,Mathf.PingPong(Time.time * 50, rotacion*2)-280, 0.0f);
        }

        if (diferencia <= -rango){
            transform.rotation = Quaternion.Euler(rotacionX, 90.0f, transform.rotation.z);
            adelante = true;
            // transform.rotation = Quaternion.Euler(0.0f,Mathf.PingPong(Time.time * 50, rotacion*2)-100, 0.0f);
        }

        if(volador) {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * velocidad, rango) + IniPos.y, transform.position.z);
        }
    }
}
