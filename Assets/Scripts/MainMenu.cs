using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Image mainPanel;
    [SerializeField] private Image highScorePanel;
    [SerializeField] private List<Text> _listText;

    private void Start()
    {
        ListHighScore.LoadHighScore();
    }

    public void HighScore()
    {
        
        List<HighScore> listHighScore = ListHighScore.HighScoreList;
        for (int i = 0; i < listHighScore.Count; i++)
        {
            HighScore highScore = listHighScore[i];
            Text text = _listText[i];
            text.text = "User: " + highScore.user + " Score: " + highScore.score;
            text.gameObject.SetActive(true);
        }
        mainPanel.gameObject.SetActive(false);
        highScorePanel.gameObject.SetActive(true);
    }

    public void BackMainMenu()
    {
        mainPanel.gameObject.SetActive(true);
        highScorePanel.gameObject.SetActive(false);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
