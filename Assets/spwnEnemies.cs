using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwnEnemies : MonoBehaviour
{
    public EnemySpawnManager EnemySpawnManager;
    // Start is called before the first frame update
    void Start()
    {
        EnemySpawnManager.SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
