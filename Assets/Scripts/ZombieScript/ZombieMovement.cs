using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    public NavMeshAgent zombie;
    public Transform zombPos;
    private int hit = 0;
    public int zombieHealth;
   // public Transform player;
    void Start()
    {
        zombie = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        zombie.SetDestination(GameObject.FindWithTag("Player").transform.position);
   
        if (hit == zombieHealth) 
        {
            Destroy(gameObject);
        }
            
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Bullet")
        {
            hit += 1;
        }
    }
}
