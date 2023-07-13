using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    float posY;
    float startDelay = 0;
    float repeatRate = 2f;
    public GameObject spawnPrefab;
    GameController controller;
    public float spawnX, spawnZ;
    


    void Start()
    {
        
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawnObstacle()
    {
        posY = Random.Range(67, 76);
        Vector3 spawnPosition = new Vector3(spawnX, posY, spawnZ);
        
        Instantiate(spawnPrefab, spawnPosition, spawnPrefab.transform.rotation);
    
    }
}
