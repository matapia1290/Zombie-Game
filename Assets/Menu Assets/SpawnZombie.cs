using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
   public GameObject zombiePrefab;
    public float timer;
    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner() 
    {
        while (true) 
        {   
            GameObject spawnedZombie = Instantiate(zombiePrefab,transform.position, Quaternion.identity);
            Destroy(spawnedZombie, 15f);
            yield return new WaitForSeconds(timer);
        }
    }
}
