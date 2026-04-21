using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public List<GameObject> zombies = new List<GameObject>();
    [SerializeField]
    private float spawnTimer;
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
            yield return new WaitForSeconds(spawnTimer);
           Instantiate(zombies[Random.Range(0,zombies.Count)], new Vector3(Random.Range(-50,50) ,2, (Random.Range(-50, 50))) + transform.position, Quaternion.identity);
            
        }
    }
}