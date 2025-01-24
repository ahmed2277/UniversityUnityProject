using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class playerMovement : MonoBehaviour
{
    public Transform lvl;
    private int totalPickups;
    private int score;
    public TextMeshProUGUI scoreText;
    public GameObject nextlvl;
    private Rigidbody rb;
    private float movX;
    private float movY;
    public float speed = 10f; // Movement speed

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevent rotation due to physics
        // Score the total number of children under the "lvl" parent
        if (lvl != null)
        {
            totalPickups = lvl.childCount;
        }
        else
        {
            Debug.LogError("Lvl parent not assigned!");
        }

        score = 0;
        nextlvl.SetActive(false);
        scoreText.text = "Score: " + score.ToString() + " / " + totalPickups;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movX = movementVector.x;
        movY = movementVector.y;
    }

    void FixedUpdate()
    {
        // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3(movX, 0.0f, movY);

        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed);
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString() + " / " + totalPickups;

        if (score >= totalPickups)
        {
            Destroy(gameObject);
            nextlvl.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
