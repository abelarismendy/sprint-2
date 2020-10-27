using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocionControlador : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0.0f,40,0.0f) * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time/2, 0.5f) +0.7f, transform.position.z);
    }
}
