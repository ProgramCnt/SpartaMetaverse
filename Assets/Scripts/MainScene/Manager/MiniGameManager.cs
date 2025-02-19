using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MiniGameManager : MonoBehaviour
{
    static MiniGameManager miniGameManager;

    private int currentScore = 0;
    private int bestScore = 0;
    private int lastScore = 0;

    public bool isGameStart = false;

    public static MiniGameManager Instance { get { return miniGameManager; } }
    GameManager gameManager;
    UIManager uiManager;

    private void Awake()
    {
        if (miniGameManager == null)
        {
            miniGameManager = this;
        }
    }

    private void Start()
    {
        gameManager = GameManager.Instance;
        uiManager = UIManager.Instance;

        bestScore = PlayerPrefs.GetInt("bestScore");            //플레이어 prefs에 저장된 int 값을 가져온다. 기본값은 0인것으로 확인
        lastScore = PlayerPrefs.GetInt("lastScore");            //마지막 점수값을 저장
    }

    public void GameOver()
    {
        Debug.Log("게임오버");
        if (bestScore < currentScore)
        {
            bestScore = currentScore;

            PlayerPrefs.SetInt("bestScore", bestScore);
        }

        uiManager.ShowResultCanvas(lastScore);
    }

    public void RestartGame()
    {
        uiManager.SetInGameScore(0);
        uiManager.ShowInfoText();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int AddScore(int score)
    {
        currentScore += score;
        return currentScore;
    }

    public void ExitGame()
    {
        //SceneManager.LoadScene();
    }

    public void UpdateScore(int score)
    {
        currentScore = score;
        uiManager.SetInGameScore(currentScore);
    }
}
