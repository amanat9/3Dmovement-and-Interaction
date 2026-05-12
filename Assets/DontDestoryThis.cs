using System.Collections;
using System.Collections.Generic;



using UnityEngine;

public class DontDestoryThis : MonoBehaviour

{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}