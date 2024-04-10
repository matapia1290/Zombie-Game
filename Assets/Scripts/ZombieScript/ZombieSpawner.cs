using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public Transform[] zombieSpawner;
    public GameObject zombiePrefab;
    public int maxZombie = 5;
    public float nextRoundTimer = 0;
    void Start()
    {
        for(int i = 0; i < maxZombie; i++) 
        {
            GameObject newZombie = Instantiate(zombiePrefab, zombieSpawner[i].position,Quaternion.identity);
        }
    }
    void Update()
    {
        nextRoundTimer+= Time.deltaTime;
        if(nextRoundTimer > 30f) 
        {
            nextRoundTimer = 0;
            for (int i = 0; i < maxZombie; i++)
            {
                GameObject newZombie = Instantiate(zombiePrefab, zombieSpawner[i].position, Quaternion.identity);
            }
        }
    }  
}
