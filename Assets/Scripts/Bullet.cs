using UnityEngine;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    private HashSet<GameObject> hitCubes = new HashSet<GameObject>(); // Track cubes already hit

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target") && !hitCubes.Contains(collision.gameObject))
        {
            Destroy(collision.gameObject); // Destroy the cube
            hitCubes.Add(collision.gameObject); // Add cube to the set of hit cubes
            Destroy(gameObject); // Destroy the bullet

            ScoreManager scoreManager = collision.transform.root.GetComponentInChildren<ScoreManager>(); // Get ScoreManager from the cube's parent

            if (scoreManager != null)
            {
                scoreManager.AddScore(1); // Increase the score
            }
        }
    }
}
