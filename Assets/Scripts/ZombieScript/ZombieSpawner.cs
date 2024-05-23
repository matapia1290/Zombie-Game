using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public Transform[] zombieSpawner;
    public GameObject zombiePrefab;
    private int maxZombie;
    public float nextRoundTimer = 0f;
    private float waveSpeed = 30f;
    void Start()
    {
        maxZombie = zombieSpawner.Length;
        for(int i = 0; i < maxZombie; i++) 
        {
            GameObject newZombie = Instantiate(zombiePrefab, zombieSpawner[i].position, Quaternion.identity);
        }
    }
    void Update()
    {
        nextRoundTimer+= Time.deltaTime;
        if(nextRoundTimer > waveSpeed) 
        {
            nextRoundTimer = 0;
            for (int i = 0; i < maxZombie; i++)
            {
                GameObject newZombie = Instantiate(zombiePrefab, zombieSpawner[i].position, Quaternion.identity);

            }
            if (waveSpeed > 15f) 
            {
                waveSpeed -= 5f;
            }
        }
    }  
}