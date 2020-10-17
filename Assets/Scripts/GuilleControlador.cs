using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuilleControlador : MonoBehaviour
{
    public float velocidad;
    public float rotacion;
    public float salto;
    public bool sobrePiso = true;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("right"))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up);
            transform.position += Vector3.right * velocidad * Time.deltaTime;

            if (sobrePiso)
            {
                transform.rotation = Quaternion.Euler(0.0f,Mathf.PingPong(Time.time * 50, rotacion*2)-280, 0.0f);
            }
        }

        if (Input.GetKey("left"))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.left, Vector3.up);
            transform.position += Vector3.left * velocidad * Time.deltaTime;

            if (sobrePiso)
            {
                transform.rotation = Quaternion.Euler(0.0f,Mathf.PingPong(Time.time * 50, rotacion*2)-100, 0.0f);
            }
        }

        if (Input.GetButtonDown("Jump") && sobrePiso)
        {
            rb.AddForce(Vector3.up*salto, ForceMode.Impulse);
            sobrePiso = false;
        }
    }

    private void OnCollisionEnter(Collision otro) {
        if (otro.gameObject.tag == "Piso")
        {
            sobrePiso = true;
        }

        if (transform.position.z < -0.3 || transform.position.z > 0.3)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
        }
    }
}
 