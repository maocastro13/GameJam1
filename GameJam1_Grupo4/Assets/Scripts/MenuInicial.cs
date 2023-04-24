using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene(1);
    }
    
    public void exit()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
