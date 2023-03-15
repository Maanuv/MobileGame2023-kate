using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public void HomeScreen()
    {
        SceneManager.LoadScene("Home");
    }
    public void nextScene()
    {
        SceneManager.LoadScene("Level2");
    }
    public void prevScene()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }
}
