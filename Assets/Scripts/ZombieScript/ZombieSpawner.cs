using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    float spawnTimer;
    float timer = 0;
    bool isNear = false;
    float randomizedSpawnTimer;
    void Start() 
    {
        spawnTimer = Random.Range(30,60);
    }
    void Update() 
    {
        if (isNear)
        {
            timer += Time.deltaTime;
            if (timer > spawnTimer)
            {

                Instantiate(zombiePrefab, gameObject.transform.position, gameObject.transform.rotation);
                timer = 0;
                spawnTimer = Random.Range(30, 60);
            }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Ally")) 
      {
            isNear = true;
      }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Ally"))
        {
            isNear = false;
        }
    }
}