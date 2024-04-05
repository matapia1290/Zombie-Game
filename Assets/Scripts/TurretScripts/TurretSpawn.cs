using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawn : MonoBehaviour
{
    public GameObject turret;
    public Transform turretSpawn;
    public bool isNear = false;
    private bool isSpawned = false;
    public float zOffset = 0;
    public float xOffset = 0;

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isNear && !isSpawned ) 
        {
            
            // Adjust this value as needed
            Vector3 spawnPosition = turretSpawn.position + new Vector3(xOffset, 0, zOffset);
            Instantiate(turret,spawnPosition,Quaternion.identity);
            isSpawned = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        isNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isNear = false;
    }
}
