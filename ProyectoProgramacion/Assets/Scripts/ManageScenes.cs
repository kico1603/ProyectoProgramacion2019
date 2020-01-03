using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    public static ManageScenes instance;
    public bool isPersistant;


    void Awake()
    {
        if (isPersistant)
        {
            if (instance == null)
            {
                instance = this as ManageScenes;
            }
            else
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            instance = this as ManageScenes;
        }
    }

    public void empezar() {
        SceneManager.LoadScene("Game");
    }

    public void menu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Menu");
    }

    public void Test()
    {
        SceneManager.LoadScene("Test");
    }

    public void salir()
    {
        Application.Quit();
    }
}

