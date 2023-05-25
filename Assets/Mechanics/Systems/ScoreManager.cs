using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public float playerHeight;
    private float highScore;
    private const string highScoreKey = "HighScore";
    public LevelHeight Player_Height;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;
    public float score = 0;
    private void Start()
    {
        LoadHighScore();
    }
    private void Update()
    {

        CalculateScore();
    }
    private void CalculateScore()
    {
        playerHeight = Player_Height.transform.position.y;
        // Assuming you have a formula to calculate the score based on the player's height

        if (!GameManager.Instance.IsDie)
        {
            score = playerHeight * 10f;
            int integerScore = Mathf.FloorToInt(score);
            ScoreText.text = integerScore.ToString();

        } // Convert to integer
        if (score > highScore)
        {
            highScore = score;
            SaveHighScore();
        }
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetFloat(highScoreKey, highScore);
        PlayerPrefs.Save();
    }

    private void LoadHighScore()
    {
        if (PlayerPrefs.HasKey(highScoreKey))
        {
            highScore = PlayerPrefs.GetFloat(highScoreKey,0);
            int integerScore = Mathf.FloorToInt(highScore); // Convert to integer
            HighScoreText.text = integerScore.ToString();
        }
        else
        {
            highScore = 0f;
        }
    }
}
