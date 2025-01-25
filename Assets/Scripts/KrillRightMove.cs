using UnityEngine;

namespace MyGameNamespace
{
    public class KrillRightMove : MonoBehaviour
    {
        [SerializeField] private float minSpeed = 2f; // Minimum speed
        [SerializeField] private float maxSpeed = 5f; // Maximum speed

        private float moveSpeed; // Randomized speed
        private Rigidbody2D rb; // Reference to the Rigidbody2D component

        void Start()
        {
            rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component

            // Generate a random speed between minSpeed and maxSpeed
            moveSpeed = Random.Range(minSpeed, maxSpeed);
        }

        void FixedUpdate()
        {
            // Move the object to the right using Rigidbody2D
            rb.MovePosition(rb.position + Vector2.left * moveSpeed * Time.fixedDeltaTime);
        }
    }
}