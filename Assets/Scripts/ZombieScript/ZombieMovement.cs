using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class ZombieMovement : MonoBehaviour
{
    public NavMeshAgent zombie;
    public Transform zombPos;
    private int hit = 0;
    public int zombieHealth;
    public int zombPoints = 0;
    public int lootDropNumber;
    public GameObject healthPack, AmmoPack;
    private GameObject player;
   // public Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        zombie = GetComponent<NavMeshAgent>();
        lootDropNumber = Random.Range(1,10);
        
    }

    // Update is called once per frame
    void Update()
    {
        zombie.SetDestination(player.transform.position);
   
        if (hit == zombieHealth) 
        {
            switch(lootDropNumber)
            {
                case 1:
                    Instantiate(healthPack, zombPos.position + Vector3.up, zombPos.rotation);
                break;
                case 2:
                    Instantiate(AmmoPack, zombPos.position + Vector3.up, zombPos.rotation);
                    break;
            }
                
            zombPoints++;
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
