using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    private int currentScore = 0;
    private int bestScore = 0;
    private int lastScore = 0;

    public bool isGameStart = false;

    public static GameManager Instance { get { return gameManager; } }
    UIManager uiManager;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
    }

    private void Start()
    {
        uiManager = UIManager.Instance;

        bestScore = PlayerPrefs.GetInt("bestScore");            //플레이어 prefs에 저장된 int 값을 가져온다. 기본값은 0인것으로 확인
        lastScore = PlayerPrefs.GetInt("lastScore");            //마지막 점수값을 저장
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt("lastScore", currentScore);
        if (bestScore < currentScore)
        {
            PlayerPrefs.SetInt("bestScore", currentScore);
        }

        uiManager.ShowResultCanvas();
    }

    public void RestartGame()
    {
        uiManager.Init();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int AddScore(int score)
    {
        currentScore += score;
        return currentScore;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void UpdateScore(int score)
    {
        currentScore = score;
        uiManager.SetInGameScore(currentScore);
    }
}
