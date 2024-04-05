using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform playerSpawn;
    void Start()
    {
        GameObject newPlayer = Instantiate(playerPrefab, playerSpawn.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
