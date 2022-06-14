using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void MainMenu() {
        SceneManager.LoadScene("MenuScene");
    }
    public void PlayGame() {
        SceneManager.LoadScene("Level01Scene");
    }
    public void GameOver() {
        SceneManager.LoadScene("GameOverScene");
    }
    public void QuitGame() {
        Application.Quit();
    }

    public void SetVolume(float pVolume)
    {
        Debug.Log("Volume:" + pVolume);
        audioMixer.SetFloat("volume", pVolume);
    }
}
