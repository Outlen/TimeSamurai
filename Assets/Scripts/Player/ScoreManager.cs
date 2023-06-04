using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int score;
    
    public TMP_Text scoreText; 

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScoreText(); 
    }

    public int GetScore()
    {
        return score;
    }

    // update the UI Text to display the current score
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
