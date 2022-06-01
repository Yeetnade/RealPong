using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private GameObject mainScreen;
    [SerializeField]
    private GameObject creditsScene;
    public void Quit()
    {
        Application.Quit();
    }

    public void Quit2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Credits()
    {
        mainScreen.SetActive(false);
        creditsScene.SetActive(true);
    }
    public void Back()
    {
        mainScreen.SetActive(true);
        creditsScene.SetActive(false);
    }
}
