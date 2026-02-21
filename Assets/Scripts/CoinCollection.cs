using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class CoinCollection : MonoBehaviour
{
    private int Count = 0;
    public TextMeshProUGUI coinText;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIITTTT");
        if (other.transform.tag == "Coin")
        {
            Count++;
            Debug.Log("COIN HIT");
            Destroy(other.gameObject);
        
        }

        if (other.transform.tag == "Flag")
        {
            Debug.Log("Secene HIITTTT");
            GotoL1();

        }
    }

    void GotoL1()
    {
        SceneManager.LoadScene("Level2");
    
    }




    private void Update()
    {
        coinText.text = "Coin Count: " + Count;
    }
}
