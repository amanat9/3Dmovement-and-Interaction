


using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    // The Singleton Instance
    public static GameStateController Instance { get; private set; }

    private bool isPaused = false;
    public string mainMenuSceneName = "MainMenu";

    void Awake()
    {
        // Ensure only one instance of this script exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && !isPaused)
        {
            GoToMainMenu();
        }
    }

    public void GoToMainMenu()
    {
        isPaused = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene(mainMenuSceneName, LoadSceneMode.Additive);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SceneManager.UnloadSceneAsync(mainMenuSceneName);
    }



}