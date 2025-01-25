using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the tag "Enemy"
        if (collision.gameObject.CompareTag("Player Wall"))
        {
            // Handle the collision with the enemy
            Debug.Log("Collided with enemy!");
            // Add any other behavior for when the player collides with the enemy
        }
        else if (collision.gameObject.CompareTag("Enemy Wall"))
        {
            // Handle collision with walls differently
            Debug.Log("Collided with wall!");
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger zone has the tag "PowerUp"
        if (other.CompareTag("PowerUp"))
        {
            // Handle picking up a power-up
            Debug.Log("Picked up a power-up!");
        }
    }
}
