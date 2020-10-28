using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Iniciar;
    public GameObject Salir;

    void Start()
    {
        Button btnIniciar = Iniciar.GetComponent<Button>();
		btnIniciar.onClick.AddListener(Jugar);
        Button btnSalir = Salir.GetComponent<Button>();
		btnSalir.onClick.AddListener(Cerrar);
    }
    void Jugar()
    {
        SceneManager.LoadScene("Nivel 1");
    }

    void Cerrar()
    {
        Application.Quit();
    }
}
