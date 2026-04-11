using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class ZombieMovement : MonoBehaviour
{
    public List<GameObject> humans = new List<GameObject>();

    public NavMeshAgent zombie;
    public Transform zombPos;
    public int zombieHealth;
    public int lootDropNumber;
    public GameObject healthPack, AmmoPack;
    private GameObject player;
    private GameObject ally;
    // public Transform player;

    PlayerStats stats;
    void Start()
    {
        


        player = GameObject.FindWithTag("Player");
        if (player!= null) 
        {
            humans.Add(player);
             stats = player.GetComponent<PlayerStats>();
        }
       
        zombie = GetComponent<NavMeshAgent>();
        lootDropNumber = Random.Range(1,10);
    }

    // Update is called once per frame
    void Update()
    {
        //ZombieRoam();
        ChooseToChase();
        RemoveNull();
        if (1  > zombieHealth) 
        { 
            Destroy(gameObject);
            switch(lootDropNumber)
            {
                case 1:
                    Instantiate(healthPack, transform.position + Vector3.up, transform.rotation);
                break;
                case 2:
                    Instantiate(AmmoPack, transform.position + Vector3.up, transform.rotation);
                    break;
            }
            stats.playerPoints++;
           
        }
            
    }
    void RemoveNull() 
    {
        if (humans.Count <= 0) return;
        for (int i = 0; i < humans.Count; i++) 
        {
            if (humans[i] == null) humans.Remove(humans[i]);
        }
    }
    void ChooseToChase() 
    {

        if (humans.Count <= 0) return;
        for (int i = 0; i < humans.Count;i++) 
        {
            if (humans[i] != null) 
            {
                float distance = Vector3.Distance(transform.position, humans[i].transform.position);

                if (distance <= 50f)
                {
                    zombie.SetDestination(humans[i].transform.position);
                }
            }

        }
    }

}
