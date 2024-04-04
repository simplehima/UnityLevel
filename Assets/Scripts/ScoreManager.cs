using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    // Update the score text display
    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    // Add score
    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScoreText();
    }
}
