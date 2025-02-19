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

        bestScore = PlayerPrefs.GetInt("bestScore");            //�÷��̾� prefs�� ����� int ���� �����´�. �⺻���� 0�ΰ����� Ȯ��
        lastScore = PlayerPrefs.GetInt("lastScore");            //������ �������� ����
    }

    public void GameOver()
    {
        Debug.Log("���ӿ���");
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
