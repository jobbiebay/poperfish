using UnityEngine;

public class BouncyBubble : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Just for debugging, adds some velocity during OnEnable")]
    private Vector3 initialVelocity;

    [SerializeField]
    private float minSpeed = 5f; // Minimum speed for the initial random speed
    [SerializeField]
    private float maxSpeed = 10f; // Maximum speed for the initial random speed

    [SerializeField]
    private float maxScale = 2f; // User-defined maximum scale
    [SerializeField]
    private float scaleIncreaseSpeed = 0.1f; // Speed at which the scale increases

    private Rigidbody2D rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();

        // Set random initial velocity
        float randomSpeed = Random.Range(minSpeed, maxSpeed); // Random speed between minSpeed and maxSpeed
        float randomX = Random.Range(-5f, 5f); // Random X direction
        float randomY = Random.Range(-5f, 5f); // Random Y direction
        initialVelocity = new Vector3(randomX, randomY, 0f).normalized * randomSpeed; // Normalize and set to random speed
        rb.linearVelocity = initialVelocity;

        // Set random initial scale
        float randomScale = Random.Range(0.5f, maxScale); // Random initial scale between 0.5 and maxScale
        transform.localScale = new Vector3(randomScale, randomScale, 1f);
    }

    private void Update()
    {
        // Gradually increase the scale towards the maxScale
        if (transform.localScale.x < maxScale)
        {
            float newScale = Mathf.Min(transform.localScale.x + scaleIncreaseSpeed * Time.deltaTime, maxScale);
            transform.localScale = new Vector3(newScale, newScale, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bounce(collision.contacts[0].normal);
    }

    private void Bounce(Vector3 collisionNormal)
    {
        // Calculate the direction after the bounce
        var direction = Vector3.Reflect(rb.linearVelocity.normalized, collisionNormal);

        // Maintain the same speed after collision
        float currentSpeed = rb.linearVelocity.magnitude; // Get the current speed
        rb.linearVelocity = direction * currentSpeed; // Set the velocity to the new direction with the same speed
    }
}