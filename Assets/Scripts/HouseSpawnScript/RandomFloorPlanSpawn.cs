using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFloorPlanSpawn : MonoBehaviour
{
    public GameObject[] floorPlans;
    void Start()
    {
        int randomizedSpawn = Random.Range(0,2);
        Instantiate(floorPlans[randomizedSpawn],gameObject.transform.position, gameObject.transform.rotation);
        Debug.Log(randomizedSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
