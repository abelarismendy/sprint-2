using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GuilleControlador : MonoBehaviour
{
    public float velocidad;
    public float rotacion;
    public float salto;
    public bool sobrePiso = true;
    public int contador;
    public int totalBugs;
    public GameObject ganar;
    public GameObject[] insectos;
    private Rigidbody rb;
    public Text bugs;

    public void Awake()
    {
        contador = 0;
        bugs.text= "BUGS: "+ contador;

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bugs")){
            other.gameObject.SetActive(false);
            contador=contador+1;
            bugs.text= "BUGS: "+ contador;
        }
        if(other.gameObject.CompareTag("malo")){
            rb.gameObject.SetActive(false);
            TerminarJuego(false ,contador);
        }
        if(other.gameObject.CompareTag("ganar")){
            TerminarJuego(true, contador);
        }
    }

    public void TerminarJuego(bool gano, int puntos){
        if (gano){
            print("ganaste!!!!");
            print(puntos);
            ReiniciarJuego();
        }
        else {
            print("perdiste!!!!");
            print(puntos);
            ReiniciarJuego();
        }

    }

    public void ReiniciarJuego(){
        contador = 0;
        bugs.text= "BUGS: "+ contador;
        rb.gameObject.SetActive(true);
        transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
        ganar.SetActive(false);
        foreach (GameObject insecto in insectos)
        {
            insecto.SetActive(true);
        }
        print("reiniciar");
    }
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
            // transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up);
            rb.rotation = Quaternion.Euler(0.0f,90.0f, 0.0f);
            transform.position += Vector3.right * velocidad * Time.deltaTime;
            if (sobrePiso){
    	        transform.rotation = Quaternion.Euler(0.0f,Mathf.PingPong(Time.time * 50, rotacion*2)-280, 0.0f);
            }
        }

        if (Input.GetKey("left"))
        {
            // transform.rotation = Quaternion.LookRotation(Vector3.left, Vector3.up);
            rb.rotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);
            transform.position += Vector3.left * velocidad * Time.deltaTime;
            if (sobrePiso){
    	        transform.rotation = Quaternion.Euler(0.0f,Mathf.PingPong(Time.time * 50, rotacion*2)-100, 0.0f);
            }
        }

        if (Input.GetButtonDown("Jump") && sobrePiso)
        {
            rb.AddForce(Vector3.up*salto, ForceMode.Impulse);
            sobrePiso = false;
        }
    }

    void LateUpdate(){
        if (contador == totalBugs){
            ganar.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision otro) {
        if (otro.gameObject.tag == "Piso")
        {
            sobrePiso = true;
        }
    }
}