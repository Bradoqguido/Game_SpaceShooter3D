using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        MenuScene,
        Level01Scene,
        GameOverScene,
    }

    public static void Load(Scene pScene)
    {
        SceneManager.LoadScene(pScene.ToString());
    }
}
