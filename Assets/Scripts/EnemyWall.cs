using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the tag "Enemy"
        if (collision.gameObject.CompareTag("Player Wall"))
        {
            // Handle the collision with the enemy
            Debug.Log("Collided with enemy!");
            // Add any other behavior for when the player collides with the enemy
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        else if (collision.gameObject.CompareTag("Enemy Wall"))
        {
            // Handle collision with walls differently
            Debug.Log("Collided with wall!");
            
        }
    }
}
