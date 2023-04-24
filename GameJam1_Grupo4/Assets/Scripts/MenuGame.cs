using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public GameObject botonPausa;
    public GameObject menuPausa;
    private bool pausaEscape= false; //pausar con la tecla scape
    private PlayerController playerControlScript;

    private void Start()
    {
        playerControlScript = GameObject.Find("PlayerSteven").GetComponent<PlayerController>();

    }

    private void Update()
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
    public void pause()
    {
        pausaEscape = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void reanudar()
    {
        pausaEscape = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 
    public void cerrar()
    {
        Debug.Log("Cerrando...");
        //Application.Quit();
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
