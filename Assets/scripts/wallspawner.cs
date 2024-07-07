using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallspawner : MonoBehaviour
{
    [SerializeField]
    public GameObject wallPrefab;
    public Transform[] gates; // Array of gate transforms
    public float minX = -3.2f;
    public float maxX = 3.2f;
    public float minDistance = 70f; // Minimum distance to other objects
    RaycastHit hit;
    private Transform spawner; // Reference to the spawner transform
    public float spawnRange = 80f; // Range within which walls can spawn in front of the spawner
    public int numWallsToSpawn = 2; // Number of walls to spawn each time

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to the spawner transform
        spawner = transform;

        // Spawn walls
        SpawnWalls();
    }

    // Function to spawn walls
    void SpawnWalls()
    {
        // Calculate minZ and maxZ based on spawner's position
        float currentMinZ = spawner.position.z;
        float currentMaxZ = currentMinZ + spawnRange;

        // Loop to spawn walls
        for (int i = 0; i < numWallsToSpawn; i++)
        {
            // Generate random position within spawn range ahead of spawner
            Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 5f, Random.Range(currentMinZ, currentMaxZ));
            GameObject obj = Instantiate(wallPrefab, randomPosition, Quaternion.identity);
            if(Physics.Raycast(obj.transform.position,obj.transform.forward*-13, out hit))
            {
                if(hit.collider.gameObject.CompareTag("gate"))
                {
                    obj.transform.position = new Vector3(wallPrefab.transform.position.x,wallPrefab.transform.position.y,wallPrefab.transform.position.z+13);
                }
            }
            if(Physics.Raycast(obj.transform.position,wallPrefab.transform.forward*13, out hit)||Physics.Raycast(obj.transform.position,wallPrefab.transform.forward*-13, out hit))
            {
                if(hit.collider.gameObject.CompareTag("gate"))
                Destroy(obj);
            }

        }
    }
}