using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guille : MonoBehaviour
{
    public float velocidad;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("right"))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up);
            transform.position += Vector3.right * velocidad * Time.deltaTime;
           
        }
        if (Input.GetKey("left"))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.left, Vector3.up);
            transform.position += Vector3.left * velocidad * Time.deltaTime;
        }
    }
}
