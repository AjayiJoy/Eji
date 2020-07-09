using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScenes : MonoBehaviour
{
    public void StartPlay()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnQuit()
    {
        //Debug.Log("Game Quit");
        Application.Quit();
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void Replay()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Exit()
    {
        SceneManager.LoadScene("MenuScene");
    }
    
}
