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

        bestScore = PlayerPrefs.GetInt("bestScore");            //�÷��̾� prefs�� ����� int ���� �����´�. �⺻���� 0�ΰ����� Ȯ��
        lastScore = PlayerPrefs.GetInt("lastScore");            //������ �������� ����
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
