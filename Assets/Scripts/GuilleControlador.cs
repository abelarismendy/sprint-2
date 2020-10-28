using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GuilleControlador : MonoBehaviour
{
    public float velocidad;
    public float rotacion;
    public float salto;
    public bool sobrePiso;
    public int totalBugs;
    public GameObject ganar;
    public GameObject[] insectos;
    Avispa1 avispa;
    private int contador;
    private Rigidbody rb;
    private Vector3 posInicial;
    public Text bugs;

    public GameObject GameFinished;
    public GameObject GameOver;
    private bool choque;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posInicial = transform.position;
        avispa = GameObject.Find("wasp").GetComponent<Avispa1>();
        GameOver.SetActive(false);
        GameObject restart = GameOver.transform.GetChild(1).gameObject;
        Button btnRestart = restart.GetComponent<Button>();
		btnRestart.onClick.AddListener(ReiniciarJuego);
        GameObject restart2 = GameFinished.transform.GetChild(1).gameObject;
        Button btnRestart2 = restart2.GetComponent<Button>();
		btnRestart2.onClick.AddListener(ReiniciarJuego);
        GameObject finish = GameOver.transform.GetChild(2).gameObject;
        Button btnFinish = finish.GetComponent<Button>();
        btnFinish.onClick.AddListener(SalirAlMenu);
        GameObject finish2 = GameFinished.transform.GetChild(2).gameObject;
        Button btnFinish2 = finish2.GetComponent<Button>();
        btnFinish2.onClick.AddListener(SalirAlMenu);

    }
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
            TerminarJuego(false);
        }
        if(other.gameObject.CompareTag("ganar")){
            TerminarJuego(true);
        }
    }

    public void TerminarJuego(bool gano){
        if (gano){
            Time.timeScale = 0;
            GameFinished.SetActive(true);
        }
        else {
            GameOver.SetActive(true);
        }

    }

    public void SalirAlMenu(){
        SceneManager.LoadScene("Menu");
    }

    public void ReiniciarJuego(){
        Time.timeScale = 1;
        contador = 0;
        bugs.text= "BUGS: "+ contador;
        rb.gameObject.SetActive(true);
        transform.position = posInicial;
        ganar.SetActive(false);
        avispa.transform.position = avispa.posInicial;
        foreach (GameObject insecto in insectos)
        {
            insecto.SetActive(true);
        }
        GameOver.SetActive(false);
        GameFinished.SetActive(false);
    }
    // Start is called before the first frame update

    void Update()
    {
    if (Input.GetKeyDown(KeyCode.P))
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey("right"))
        {
            // transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up);
            rb.rotation = Quaternion.Euler(0.0f,90.0f, 0.0f);
            transform.position += Vector3.right * velocidad * Time.deltaTime;
            if (sobrePiso && !choque){
    	        transform.rotation = Quaternion.Euler(0.0f,Mathf.PingPong(Time.time * 50, rotacion*2)-280, 0.0f);
            }
        }

        if (Input.GetKey("left"))
        {
            // transform.rotation = Quaternion.LookRotation(Vector3.left, Vector3.up);
            rb.rotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);
            transform.position += Vector3.left * velocidad * Time.deltaTime;
            if (sobrePiso && !choque){
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
        if (contador >= totalBugs){
            ganar.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision otro) {
        if (otro.gameObject.tag == "Piso")
        {
            sobrePiso = true;
        }

        else {
            choque = true;
        }
    }
    private void OnCollisionExit() {
        choque = false;
    }
}