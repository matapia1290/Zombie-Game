using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
   public GameObject zombiePrefab;
    public GameObject lightGunFire;
    public float gunfireTimer;
    public float zombieSpawnTimer;
    void Start()
    {
        StartCoroutine(Spawner());
        StartCoroutine(MenuGunfire());
    }

    IEnumerator Spawner() 
    {
        while (true) 
        {   
            GameObject spawnedZombie = Instantiate(zombiePrefab,transform.position, Quaternion.identity);
            Destroy(spawnedZombie, 15f);
            yield return new WaitForSeconds(zombieSpawnTimer);
        }
    }

    IEnumerator MenuGunfire()
    {
        while (true) 
        {
            gunfireTimer = Random.Range(0.1f, gunfireTimer);
            lightGunFire.SetActive(false);
            yield return new WaitForSeconds(gunfireTimer);
            lightGunFire.SetActive(true);
            yield return new WaitForSeconds(gunfireTimer/2);
            gunfireTimer = Random.Range(1f, gunfireTimer);
        }
    }
}
