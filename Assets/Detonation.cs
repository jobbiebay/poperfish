using UnityEngine;

public class Detonation : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Instead of immediately killing the player
            //Add a condition to deduct a Life point
            //If all Life points are depleted, Kill the player and Game over
            Destroy(other.gameObject);
        } else if (other.gameObject.CompareTag("Krillet"))
        {
            //Add a condition to Score the player on Bomble destruction
            //Score is based on the scale
            //Either smaller = better OR bigger = better score
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

