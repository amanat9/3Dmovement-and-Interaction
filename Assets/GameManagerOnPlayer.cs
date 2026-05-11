using UnityEngine;

public class GameManagerOnPlayer : MonoBehaviour
{
    public GameObject ScrollCanvas;

    private bool isScrollCanvasOpen = false;

    void Start()
    {
        if (ScrollCanvas != null)
        {
            ScrollCanvas.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleScrollCanvas();
        }
    }

    private void ToggleScrollCanvas()
    {
        if (ScrollCanvas == null)
        {
            return;
        }

        if (isScrollCanvasOpen)
        {
            CloseScrollCanvas();
        }
        else
        {
            OpenScrollCanvas();
        }
    }

    private void OpenScrollCanvas()
    {
        isScrollCanvasOpen = true;
        ScrollCanvas.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void CloseScrollCanvas()
    {
        isScrollCanvasOpen = false;
        ScrollCanvas.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
