using UnityEngine;

public class ScrollCanvasScript : MonoBehaviour
{
    public GameObject ScrollCanvas;

    void Start()
    {
        if (ScrollCanvas != null)
        {
            ScrollCanvas.SetActive(false);
        }
    }
}
