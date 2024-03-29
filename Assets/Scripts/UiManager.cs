﻿using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UiManager: MonoBehaviour
{
    public static UiManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    
    private bool isPaused;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Update()
    {
        if (!Input.GetButtonDown("Cancel"))
        {
            return;
        }
        if (isPaused)
        {
            Unpause();
        }
        else
        {
            Pause();
        }
    }

    private void Pause()
    {
        MenuManager.Instance.ToggleCanvas(MenuName.Pause);
        TogglePause();
    }

    public void Unpause()
    {
        MenuManager.Instance.ToggleCanvas(MenuName.ScoreCounter);
    }

    public void TogglePause()
    {
        Time.timeScale = isPaused ? 1 : 0;
        ColumnsMovement.CanMove = isPaused;
        GameManager.Instance.playerInput.enabled = isPaused;
        isPaused = !isPaused;
    }
    
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMain()
    {
        if (isPaused)
        {
            TogglePause();
        }
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateHighScore()
    {
        highScoreText.text = HighScoreController.LoadHighScore().ToString();
    }
}