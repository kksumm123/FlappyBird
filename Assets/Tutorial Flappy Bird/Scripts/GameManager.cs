using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool isGameOver = false;
    static public GameManager instace;
    private void Awake()
    { instace = this; ShowGameOver(false); }

    // 기둥 통과할때마다 Score + 100
    // 새가 죽으면 게임 종료 UI표시
    public GameObject gameOverUI;
    public Text scoreUI;
    public float scrollSpeedMult = 1;
    public void SetGameOver()
    {
        isGameOver = true;
        ShowGameOver(true);
    }
    internal void ShowGameOver(bool active)
    {
        gameOverUI.SetActive(active);
    }

    int score = 0;
    internal void AddScore(int addValue)
    {
        score += addValue;
        scoreUI.text = "Score : " + score;
    }
    private void Update()
    {
        if (isGameOver)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                // 게임 재시작
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
