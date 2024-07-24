

This is a zombie game to practice unity 3D.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleSpawn : MonoBehaviour
{
    public GameObject[] obsticles;
    public Transform spawnPoint;
    public float spawnTimer = 3;
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Timer() 
    {
        while (true) 
        {
            float randomObsticle = (Random.Range(0, (obsticles.Length)));
            yield return new WaitForSeconds(spawnTimer);
            Instantiate(obsticles[Mathf.RoundToInt(randomObsticle)],spawnPoint);
        }
    }
}


