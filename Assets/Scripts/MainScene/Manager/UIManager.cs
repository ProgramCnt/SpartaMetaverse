using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static UIManager uiManager;
    public static UIManager Instance { get { return uiManager; } }

    public Button restartButton;
    public Button exitButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI inGameScoreText;
    public TextMeshProUGUI infoText;
    public Canvas resultCanvas;
    public Canvas inGameUI;

    GameManager gameManager;

    private void Awake()
    {
        if (uiManager == null)
        {
            uiManager = this;
        }
    }

    private void Start()
    {
        gameManager = GameManager.Instance;

        if (scoreText == null)
        {
            return;
        }

        if (bestScoreText == null)
        {
            return;
        }

        if (resultCanvas == null)
        {
            return;
        }

        if (resultCanvas == null)
        {
            return;
        }

        restartButton.onClick.AddListener(gameManager.RestartGame);
        exitButton.onClick.AddListener(gameManager.ExitGame);
    }

    public void Init()
    {
        if (SceneManager.GetActiveScene().name.Equals("MainScene"))
        {

        }
        else if(SceneManager.GetActiveScene().name.Equals("MiniGameScene"))
        {
            SetInGameScore(0);
            ShowInfoText();
        }
    }

    public void ShowResultCanvas()
    {
        resultCanvas.gameObject.SetActive(true);
        inGameUI.gameObject.SetActive(false);
        bestScoreText.text = PlayerPrefs.GetInt("bestScore").ToString();
    }

    public void HideResultCanvas()
    {
        resultCanvas.gameObject.SetActive(false);
        inGameUI.gameObject.SetActive(true);
        infoText.gameObject.SetActive(false);
    }

    public void SetInGameScore(int score)
    {
        inGameScoreText.text = score.ToString();
        scoreText.text = score.ToString();
    }

    public void ShowInfoText()
    {
        resultCanvas.gameObject.SetActive(false);
        inGameUI.gameObject.SetActive(false);
        infoText.gameObject.SetActive(true);
    }
}
