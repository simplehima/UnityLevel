using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Added for SceneManager

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    // Update the score text display
    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;

        // Check if the score reaches 10
        if (score >= 10)
        {
            OpenLevel2();
        }
    }

    // Add score
    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScoreText();
    }

    // Load Level2 scene
    private void OpenLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
}
