using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public float moveSpeed = 12f; // Speed of movement
    public float minX = -5f; // Left boundary
    public float maxX = 5f; // Right boundary

    private int direction = 1; // 1 for right, -1 for left

    void Start()
    {
        // Determine initial direction based on starting position
        if (transform.position.x >= maxX)
        {
            direction = -1; // Start moving left
        }
        else if (transform.position.x <= minX)
        {
            direction = 1; // Start moving right
        }
    }

    void Update()
    {
        // Calculate the new position
        float newX = transform.position.x + direction * moveSpeed * Time.deltaTime;

        // Check if the platform has reached the boundaries
        if (newX > maxX)
        {
            newX = maxX;
            direction = -1; // Reverse direction
        }
        else if (newX < minX)
        {
            newX = minX;
            direction = 1; // Reverse direction
        }

        // Apply the new position
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
