using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    static public GameManager instace;
    Text highScoreText;
    // 최고 점수 저장, 게임 시작시 초기화, 게임 중 점수 넘기면 UI와 함께 갱신
    int highScore;
    //하이스코어 갱신 속성버전
    int HighScore
    {
        set
        {
            highScore = value;
            if (highScoreText == null)
                highScoreText = GameObject.Find("Canvas").transform.Find("HighScore").GetComponent<Text>();

            highScoreText.text = $"High Score : {highScore.ToNumber()}";
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }
    // 하이스코어 갱신 함수버전
    private void SetHighScore(int _highScore)
    {
        highScore = _highScore;
        highScoreText.text = $"High Score : {highScore.ToNumber()}";
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }


    private void Awake()
    {
        instace = this;
        ShowGameOver(false);
        highScore = PlayerPrefs.GetInt("HighScore");
        //함수버전
        //SetHighScore(highScore);
        //속성버전
        HighScore = highScore;
    }

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

        if (score > highScore)
        {
            //함수버전
            //SetHighScore(highScore);
            //속성버전
            HighScore = score;
        }
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
