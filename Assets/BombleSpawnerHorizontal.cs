using UnityEngine;
using System.Collections;

public class BombleSpawnerHorizontal : MonoBehaviour
{
    [SerializeField] private float spawnRate = 6f; // Rate at which krill spawn
    [SerializeField] private GameObject bomblePrefab; // Prefab to spawn
    [SerializeField] private bool canSpawn = true; // Control spawning
    [SerializeField] private float minX = -10f; // Minimum X position for spawning
    [SerializeField] private float maxX = 10f; // Maximum X position for spawning

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
            float randomY = Random.Range(minX, maxX);

            // Instantiate the krillPrefab at the current X position and the random Y position
            Instantiate(bomblePrefab, new Vector3(transform.position.x, randomY, transform.position.z), Quaternion.identity);
        }
    }
}
