﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insectos : MonoBehaviour
{
    public float rotationSpeed = 50;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed  *Time.deltaTime);
        
    }
     private void OntriggerEnter (Collider other)
     {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
        }
     }
}