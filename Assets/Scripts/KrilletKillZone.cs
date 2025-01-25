using UnityEngine;

public class KrilletKillZone : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Krillet"))
        {
            Destroy(other.gameObject);
        }
    }
}
