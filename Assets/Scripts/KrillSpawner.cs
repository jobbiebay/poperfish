using System.Collections;
using UnityEngine;

public class KrillSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 2f; // Rate at which krill spawn
    [SerializeField] private GameObject krillPrefab; // Prefab to spawn
    [SerializeField] private bool canSpawn = true; // Control spawning
    [SerializeField] private float minY = -5f; // Minimum Y position for spawning
    [SerializeField] private float maxY = 5f; // Maximum Y position for spawning

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;

            // Generate a random Y position within the specified range
            float randomY = Random.Range(minY, maxY);

            // Instantiate the krillPrefab at the current X position and the random Y position
            Instantiate(krillPrefab, new Vector3(transform.position.x, randomY, transform.position.z), Quaternion.identity);
        }
    }
}