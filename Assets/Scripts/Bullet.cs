using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);

        // Check if the collided object has a ScoreManager component
        ScoreManager cubeScoreManager = collision.gameObject.GetComponent<ScoreManager>();
        if (cubeScoreManager != null)
        {
            // If it does, increase the score
            cubeScoreManager.AddScore(1);
            cubeScoreManager.UpdateScore(); // Update the score display
        }
    }
}
