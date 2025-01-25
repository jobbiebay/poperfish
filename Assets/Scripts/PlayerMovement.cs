using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Movement speed
    public float rotationSpeed = 10f;  // Speed at which player rotates

    private Vector2 targetPosition;

    void Update()
    {
        // Get the mouse position in world space
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Ignore Z-axis (we are in 2D)
        targetPosition = new Vector2(targetPosition.x, targetPosition.y);

        // Move player towards the mouse position
        Vector2 currentPosition = transform.position;
        transform.position = Vector2.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);

        // Make the player face the mouse position
        FaceMouse();
    }

    void FaceMouse()
    {
        // Get direction vector from the player to the mouse
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        // Calculate the angle in radians between the player and the mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the player to face the mouse position smoothly
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
