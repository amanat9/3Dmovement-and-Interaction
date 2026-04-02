using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement; // Required for changing scenes

public class EnemySpawnManager : MonoBehaviour
{
    [Header("Spawning Settings")]
    public GameObject enemyPrefab;
    public int numberOfEnemiesToSpawn = 5;

    [Header("Spawn Area Bounds")]
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    [Header("Level Management")]
    public string nextLevelName; // Type the exact name of your next scene here

    // The list that tracks all active enemies
    private List<GameObject> activeEnemies = new List<GameObject>();

    // Ensures we don't try to load the level before spawning is finished
    private bool hasSpawned = false;

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            // 1. Pick a random X and Z within the ranges you set
            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minZ, maxZ);

            // 2. Find the correct Y height so they don't spawn inside or floating above the terrain
            float yPos = 0f;
            if (Terrain.activeTerrain != null)
            {
                yPos = Terrain.activeTerrain.SampleHeight(new Vector3(randomX, 0, randomZ));
            }

            // 3. Create the spawn position
            Vector3 spawnPosition = new Vector3(randomX, yPos, randomZ);

            // 4. Instantiate the enemy and add it to our tracking list
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            activeEnemies.Add(newEnemy);
        }

        // Spawning is complete, allow the Update loop to start checking the list
        hasSpawned = true;
    }

    void Update()
    {
        if (!hasSpawned) return;

        // This removes any enemies from the list that have been Destroyed()
        // When a GameObject is destroyed in Unity, it becomes 'null'
        activeEnemies.RemoveAll(enemy => enemy == null);

        // Check if the list has hit 0
        if (activeEnemies.Count == 0)
        {
            Debug.Log("All enemies killed.");
            //LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        // Set to false so this doesn't trigger repeatedly while the scene loads
        hasSpawned = false;

        // Load the next level
        SceneManager.LoadScene(nextLevelName);
    }
}