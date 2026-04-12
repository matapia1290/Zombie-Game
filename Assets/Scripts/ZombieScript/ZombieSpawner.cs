using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public List<GameObject> zombies = new List<GameObject>();
    PlayerStats player;
    void Start() 
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner() 
    {
        while (player.playerHealth > 0) 
        {
            yield return new WaitForSeconds(Random.Range(0,2));
           Instantiate(zombies[Random.Range(0,zombies.Count)], new Vector3(Random.Range(-350,350) ,2, (Random.Range(-350, 350))) + transform.position, Quaternion.identity);
            
        }
    }
}