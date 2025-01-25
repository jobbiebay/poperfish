using UnityEngine;

public class Consume : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Krill"))
        {
            //Only collides with "Krill"
            //Increment a State when collide
            //Otherwise, nothing changes when full
            //OPTIONAL: Extra points when consuming Krill after full State
            Destroy(collision.gameObject);
        }
    }
}
