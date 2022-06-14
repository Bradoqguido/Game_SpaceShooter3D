using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Loader.Load(Loader.Scene.Level01Scene);
    }

    public void Sair()
    {
        Debug.Log("Saindo!");
        Application.Quit();
    }
}
