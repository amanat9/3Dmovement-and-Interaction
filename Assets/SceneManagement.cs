using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for loading scenes

public class SceneManagement : MonoBehaviour
{
    // This creates a global reference to this script (Singleton)
    public static SceneManagement Instance;

    [Header("List of Levels")]
    [Tooltip("Type the exact names of your scenes in the order they should be played.")]
    public List<string> sceneNames = new List<string>();

    // Tracks which level we are currently on in the list
    private int currentSceneIndex = 0;

    void Awake()
    {
        // Singleton Setup: Ensures only one SceneManagement exists at a time
        if (Instance == null)
        {
            Instance = this;
            // Keeps this manager alive when a new scene loads
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // The method that other scripts will call
    public void LoadNextScene()
    {
        // Move to the next index in the list
        currentSceneIndex++;

        // Check if we still have scenes left in the list to load
        if (currentSceneIndex < sceneNames.Count)
        {
            string nextScene = sceneNames[currentSceneIndex];
            Debug.Log("Loading next scene: " + nextScene);
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            // What happens when you beat the last level
            Debug.Log("All levels completed! You win!");

            // Optional: Reset back to the first level
            // currentSceneIndex = 0;
            // SceneManager.LoadScene(sceneNames[currentSceneIndex]);
        }
    }
}