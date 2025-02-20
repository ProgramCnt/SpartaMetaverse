using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    private bool isPlayerEnter = false;
    public Canvas scoreCanvas;
    public Canvas interactionCanvas;
    private bool loadSceneOnce = true;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        isPlayerEnter = true;

        if (gameObject.CompareTag("ScoreNpc"))
        {
            scoreText.text = PlayerPrefs.GetInt("lastScore").ToString();
            bestScoreText.text = PlayerPrefs.GetInt("bestScore").ToString();
            scoreCanvas.gameObject.SetActive(true);
            interactionCanvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        if (gameObject.CompareTag("ScoreNpc"))
        {
            if (Input.GetKey(KeyCode.F))
            {
                if (loadSceneOnce)
                {
                    loadSceneOnce = false;
                    SceneManager.LoadScene("MiniGameScene");
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        isPlayerEnter = false;

        if (gameObject.CompareTag("ScoreNpc"))
        {
            scoreCanvas.gameObject.SetActive(false);
            interactionCanvas.gameObject.SetActive(false);
        }
    }
}