using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    public GameObject botonPlay;
    public GameObject menuGameOver;
    //private bool pausaEscape= false; //pausar con la tecla scape
    private PlayerController playerControlScript;

    /*private void Start()
    {
        playerControlScript = GameObject.Find("PlayerSteven").GetComponent<PlayerController>();

    }*/

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausaEscape)
            {
                reanudar();
            }
            else
            {
                pause();
            }
        }
    }
   /* public void pause()
    {
        //pausaEscape = true;
        Time.timeScale = 0f;
        botonPlay.SetActive(false);
        menuGameOver.SetActive(true);
    }*/

    public void reanudar()
    {
       // pausaEscape = false;
        Time.timeScale = 1f;
        botonPlay.SetActive(true);
        menuGameOver.SetActive(false);
    }

    public void reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("CoreGameMain");
    } 
    public void cerrar()
    {
        Debug.Log("Cerrando...");
        Application.Quit();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
