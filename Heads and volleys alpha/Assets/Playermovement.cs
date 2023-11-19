using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    private Camera mainCamera;

    void Start()
    {
        // Assuming the camera is tagged as "MainCamera"
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Get the horizontal input (A and D keys, or left and right arrow keys)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the movement vector
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);

        // Move the player
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Get the camera boundaries in world coordinates
        float cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float minX = mainCamera.transform.position.x - cameraHalfWidth;
        float maxX = mainCamera.transform.position.x + cameraHalfWidth;

        // Clamp the player's X position to stay within the camera's view
        float playerX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(playerX, transform.position.y, transform.position.z);
    }
}