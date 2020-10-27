using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverManager : MonoBehaviour
{
    public GameObject GameOver;
    public static GameOverManager gameOverManager;
    // Start is called before the first frame update
    void Start()
    {
        gameOverManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CallGameOver()
    {
        GameOver.SetActive (true);
    }
}
