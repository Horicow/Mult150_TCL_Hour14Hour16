using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 5f; // Movement speed of the ball
    public GameObject gameOverPanel; // UI panel for Game Over (assign in Inspector)

    private void Update()
    {
        // Ball forward movement
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Optional: Player-controlled horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D or Left/Right keys
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Tube")
        {
            // Trigger Game Over logic
            Debug.Log("Game Over! The ball collided with a Tube.");
            gameOverPanel.SetActive(true); // Show Game Over UI
            Time.timeScale = 0; // Pause the game
        }
    }
}
