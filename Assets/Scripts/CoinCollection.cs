using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollection : MonoBehaviour
{
    private int Count = 0;
    public TextMeshProUGUI coinText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Coin")
        {
            Count++;
            Debug.Log("COIN HIT");
            Destroy(other.gameObject);
        
        }
    }

    private void Update()
    {
        coinText.text = "Coin Count: " + Count;
    }
}
