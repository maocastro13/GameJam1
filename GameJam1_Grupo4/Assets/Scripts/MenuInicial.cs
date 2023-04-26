using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("CoreGameScene");
    }
    
    public void exit()
    {
        Debug.Log("Salir...");
        //Only active next line if Game is built to App:
        //Application.Quit();
    }
}
