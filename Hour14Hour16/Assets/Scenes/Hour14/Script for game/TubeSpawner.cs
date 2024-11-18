using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSpawner : MonoBehaviour
{
    public GameObject tubePrefab; // Assign the prefab named "Tube" in Inspector
    public float spawnInterval = 2f; // Time between spawns
    public float tubeSpeed = 5f; // Speed of the tubes moving toward the player
    public float spawnRangeX = 5f; // Horizontal range for tube positions
    public float destroyAfter = 10f; // Destroy tubes after this duration

    private void Start()
    {
        StartCoroutine(SpawnTubes());
    }

    private IEnumerator SpawnTubes()
    {
        while (true)
        {
            // Spawn a new tube
            GameObject tube = Instantiate(tubePrefab, GenerateRandomPosition(), Quaternion.identity);
            tube.name = "Tube"; // Ensure spawned tubes are named "Tube"

            // Add movement to the tube
            Rigidbody tubeRb = tube.AddComponent<Rigidbody>();
            tubeRb.useGravity = false; // Disable gravity for tubes
            tubeRb.velocity = Vector3.back * tubeSpeed;

            // Destroy tube after a delay
            Destroy(tube, destroyAfter);

            // Wait before spawning the next tube
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        return new Vector3(randomX, 0, transform.position.z);
    }
}
