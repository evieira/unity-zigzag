using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{

    [SerializeField] private Text pauseText;
    [SerializeField] private Canvas _pauseCanvas;

    private void Update()
    {
        if(!Input.GetKeyDown(KeyCode.Escape)) return;
        
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        _pauseCanvas.gameObject.SetActive(Time.timeScale == 0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
